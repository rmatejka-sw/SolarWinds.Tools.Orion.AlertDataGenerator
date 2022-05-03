using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SolarWinds.Tools.NetworkGenerator.ModelGenerator
{
    /// <summary>
    /// Adapted from
    /// https://bitbucket.solarwinds.com/projects/NPM/repos/netpath/browse/Src/Lib/SolarWinds.NetPath.Test.Common/TraceRouteGraphGenerator.cs
    /// Generates a list of paths representing a typical internet topology where a path
    /// is connected through one or more Autonomous Systems (AS) which have their own internal structure
    /// </summary>
    public class InternetNetworkGenerator
    {
        private readonly int totalHops;
        private readonly int minNodes;
        private readonly bool includeInternalMachines;
        private readonly Bogus.Faker faker;
        private string currentDomainName;
        private string currentNetworkCidrPrefix;
        private int currentAsNumber;
        private string currentNetworkId;
        private readonly IDictionary<int, IList<Device>> autonomousSystemNodes = new Dictionary<int, IList<Device>>();
        private readonly Dictionary<int, List<List<Device>>> autonomousSystemNodeLayers = new Dictionary<int, List<List<Device>>>();
        private readonly IList<Device> networkDevices = new List<Device>();
        private int minInternalNodes;
        private int maxInternalNodes;
        private int maxConnectionsBetweenNodes;

        public InternetNetworkGenerator(NetGenConfig netGenConfig)
        {
            this.maxInternalNodes = netGenConfig.MaxInternalNodes > 0 ? netGenConfig.MaxInternalNodes : 5;
            this.maxConnectionsBetweenNodes = netGenConfig.MaxConnectionsBetweenNodes > 0 ? netGenConfig.MaxConnectionsBetweenNodes : 1;
            this.minInternalNodes = maxInternalNodes / 4;
            this.totalHops = netGenConfig.MaxHops > 0 ? netGenConfig.MaxHops : 15;
            this.minNodes = netGenConfig.MinNodes > 0 ? netGenConfig.MinNodes : 100;

            this.includeInternalMachines = true;

            this.faker = new Bogus.Faker();
            CreateNetworks();
        }

        public int TotalNetworks { get; private set; }

        public IList<Device> Devices { get; } = new List<Device>();
        public IList<DeviceConnection> DeviceConnections { get; } = new List<DeviceConnection>();
        public IList<DeviceInterface> DeviceInterfaces { get; } = new List<DeviceInterface>();

        private void CreateNetworks()
        {
            while (this.Devices.Count < this.minNodes)
            {
                var lastDevice = this.Devices.LastOrDefault();
                this.currentNetworkId = $"NETWORK{this.TotalNetworks + 1}";
                CreateNetwork();
                this.TotalNetworks += 1;
                if (lastDevice != null)
                {
                    ConnectDevices(lastDevice, this.Devices.Last());
                }
            }
        }

        private void CreateNetwork()
        {
            try
            {
                var randomTotalHops = this.faker.Random.Int(this.totalHops, this.totalHops * 2);
                var internalNodeCount = this.faker.Random.Int(1, randomTotalHops / 4);
                var internalNodes = new List<Device>();
                this.networkDevices.Clear();
                this.autonomousSystemNodes.Clear();
                UpdateCurrentNetwork();
                for (int i = 0; i < randomTotalHops; i++)
                {
                    var isInternal = (i < internalNodeCount) || (i == randomTotalHops - 1);
                    var internalSubnet = CreateRandomIpAddress(isPrivate: true, subnets: 3).Replace(".0", "");
                    var internalDomainName = this.faker.Internet.DomainName();
                    var device = CreateDeviceNode(isInternal ? internalSubnet : String.Empty, isInternal ? internalDomainName : String.Empty);
                    this.Devices.Add(device);
                    this.networkDevices.Add(device);
                    if (isInternal)
                    {
                        internalNodes.Add(device);
                    }

                    AddAutonomousSystemNode(device);
                }

                CreateTraceRouteGraphEdges();
                CreateTraceRouteGraphAsNodes();
                if (this.includeInternalMachines)
                {
                    foreach (var device in internalNodes)
                    {
                        AddInternalSubnetDevices(device);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private Device CreateDeviceNode(string internalSubnet = "", string internalDomainName = "")
        {
            var isInternal = !String.IsNullOrEmpty(internalSubnet);
            var ipAddress = isInternal
                                ? CreateRandomIpAddress(internalSubnet)
                                : CreateRandomIpAddress(this.currentNetworkCidrPrefix.Replace(".0", ""));
            var domainName = isInternal
                                 ? CreateRandomDomainName(ipAddress, internalDomainName)
                                 : CreateRandomDomainName(ipAddress, this.currentDomainName);
            return new Device
            {
                DeviceIndex = this.Devices.Count + 1,
                IpAddress = ipAddress,
                NodeName = domainName,
                AsNumber = isInternal ? 0 : this.currentAsNumber,
                CidrPrefix = isInternal ? null : this.currentNetworkCidrPrefix,
                DomainName = isInternal ? internalDomainName : this.currentDomainName,
                NetworkId = this.currentNetworkId
            };
        }

        private void AddInternalSubnetDevices(Device parentDevice)
        {
            var subnetAddress = String.Join(".", parentDevice.IpAddress.Split('.').Take(3));
            //
            var totalDevice = this.faker.Random.Int(this.minInternalNodes, this.maxInternalNodes);
            // 80% of internals will use minimum
            totalDevice = (this.faker.Random.Int(1,100) > 80 ? totalDevice : this.minInternalNodes);
            int? sourceDeviceInterfaceIndex = null;
            parentDevice.IsLocalDevice = true;
            for (int deviceAddress = 1; deviceAddress <= totalDevice; deviceAddress++)
            {
                var ipAddress = $"{subnetAddress}.{deviceAddress}";
                if (ipAddress == parentDevice.IpAddress)
                {
                    continue;
                }

                var fake = new Bogus.Faker();
                var nodeName = $"{fake.Person.FirstName[0]}{fake.Person.LastName}";
                var device = new Device
                {
                    DeviceIndex = this.Devices.Count + 1,
                    IpAddress = ipAddress,
                    NodeName = nodeName,
                    DomainName = $"{nodeName}.{parentDevice.DomainName}",
                    NetworkId = this.currentNetworkId,
                    IsLocalDevice = true,
                    IsServer = true
                };
                this.Devices.Add(device);
                var connection = ConnectDevices(parentDevice, device, sourceDeviceInterfaceIndex);
                if (sourceDeviceInterfaceIndex == null)
                {
                    sourceDeviceInterfaceIndex = connection?.SourceDeviceInterfaceIndex;
                }
            }
        }

        private void AddAutonomousSystemNode(Device node)
        {
            try
            {
                if (IsPrivateIp(node.IpAddress))
                {
                    return;
                }

                if (!this.autonomousSystemNodes.ContainsKey(node.AsNumber))
                {
                    this.autonomousSystemNodes[node.AsNumber] = new List<Device>();
                }

                this.autonomousSystemNodes[node.AsNumber].Add(node);
                // Randomly switch to new network after at least 2 nodes have been added
                if (this.autonomousSystemNodes[node.AsNumber].Count < 2 || this.faker.Random.Int(0, 5) > 0)
                {
                    return;
                }

                UpdateCurrentNetwork();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private bool IsPrivateIp(string ipAddress)
        {
            if (String.IsNullOrEmpty(ipAddress))
            {
                return false;
            }

            return Regex.IsMatch(ipAddress, @"(^127\.0\.0\.1)|(^10\.)|(^172\.1[6-9]\.)|(^172\.2[0-9]\.)|(^172\.3[0-1]\.)|(^192\.168\.)");
        }

        private void UpdateCurrentNetwork()
        {
            var subnets = this.faker.Random.Int(2, 3);
            this.currentNetworkCidrPrefix = CreateRandomIpAddress(subnets: subnets);
            this.currentAsNumber = this.faker.Random.Int(100, 65535);
            this.currentDomainName = this.faker.Internet.DomainName();
        }

        private void CreateTraceRouteGraphEdges()
        {
            try
            {
                for (int i = 0; i < this.networkDevices.Count - 1; i++)
                {
                    var sourceNode = this.networkDevices[i];
                    var targetNode = this.networkDevices[i + 1];
                    ConnectDevices(sourceNode, targetNode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private DeviceConnection ConnectDevices(Device sourceDevice, Device targetDevice, int? sourceDeviceInterfaceIndex = null)
        {
            if (this.DeviceConnections.Any(c => c.SourceDeviceIndex == sourceDevice.DeviceIndex && c.TargetDeviceIndex == targetDevice.DeviceIndex))
            {
                return null;
            }
            int maxConnections = this.maxConnectionsBetweenNodes>1 ? this.faker.Random.Int(1,this.maxConnectionsBetweenNodes) : 1;
            // 95% will have 1 connection
            maxConnections =  this.faker.Random.Int(1,100) > 95 ? maxConnections : 1;
            for (int connectionCount = 0; connectionCount < maxConnections; connectionCount++)
            {
                this.DeviceConnections.Add(
                    new DeviceConnection
                    {
                        SourceDeviceIndex = sourceDevice.DeviceIndex,
                        TargetDeviceIndex = targetDevice.DeviceIndex,
                        SourceDeviceInterfaceIndex = sourceDeviceInterfaceIndex ?? CreateDeviceInterface(sourceDevice).InterfaceIndex,
                        TargetDeviceInterfaceIndex = CreateDeviceInterface(targetDevice).InterfaceIndex,
                        NetworkId = this.currentNetworkId
                    });

            }
            return this.DeviceConnections.Last();
        }

        private DeviceInterface CreateDeviceInterface(Device device)
        {
            var deviceInterface = new DeviceInterface
            {
                DeviceIndex = device.DeviceIndex,
                InterfaceIndex = device.TotalInterfaces,
                Name = $"{device.NodeName} - eth{device.TotalInterfaces}",
                NetworkId = this.currentNetworkId
            };
            device.TotalInterfaces += 1;
            this.DeviceInterfaces.Add(deviceInterface);
            return deviceInterface;
        }

        private void CreateTraceRouteGraphAsNodes()
        {
            try
            {
                foreach (var asNumber in this.autonomousSystemNodes.Keys)
                {
                    int layers = 0;
                    while (new Bogus.Faker().Random.Int(0, 8) > 4 || layers < 2)
                    {
                        ExpandAutonomousSystemNodes(asNumber);
                        layers += 1;
                    }
                }

                CrossLinkAsNodeLayers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ExpandAutonomousSystemNodes
        /// For the original set of N nodes associated with asNumber,
        /// Creates N-2 new nodes and links the first node of the new
        /// set to the first node in the original set and the last node in
        /// the new set to the last node in the new set resulting in a structure
        /// like so:
        /// -> A -> A -> A -> A -> A ->
        ///     \-> B -> B -> B --/
        /// and adds the original set of nodes minus the start and the end node
        /// and the new set of nodes to autonomousSystemNodeLayers for further
        /// processing by CrossLinkAsNodeLayers.
        /// </summary>
        /// <param name="asNumber"></param>
        private void ExpandAutonomousSystemNodes(int asNumber)
        {
            try
            {
                var nodes = this.autonomousSystemNodes[asNumber];
                if (nodes.Count <= 2)
                {
                    return;
                }

                var firstNode = nodes[0];
                var lastNode = nodes[nodes.Count - 1];
                var sourceNode = firstNode;
                var targetNode = lastNode;
                // Create another layer of N nodes
                var maxNodes = Math.Max(1, this.faker.Random.Int(nodes.Count - 2, nodes.Count));
                this.currentNetworkCidrPrefix = firstNode.CidrPrefix;
                this.currentDomainName = firstNode.DomainName;
                Device newNode = null;
                var newNodes = new List<Device>();
                while (newNodes.Count < maxNodes)
                {
                    newNode = CreateDeviceNode();
                    this.Devices.Add(newNode);
                    ConnectDevices(sourceNode, newNode);
                    sourceNode = newNode;
                    newNodes.Add(newNode);
                }

                ConnectDevices(newNode, targetNode);
                var replacedNodes = (from n in nodes where n.DeviceIndex != firstNode.DeviceIndex && n.DeviceIndex != targetNode.DeviceIndex select n).ToList();
                if (!this.autonomousSystemNodeLayers.ContainsKey(asNumber))
                {
                    this.autonomousSystemNodeLayers[asNumber] = new List<List<Device>> { replacedNodes };
                }

                this.autonomousSystemNodeLayers[asNumber].Add(newNodes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Nasty. For each list of nodes for a given as in autonomousSystemNodeLayers,
        /// generates random edges between adjacent "layers" - nodes at the same relative
        /// location in the list. For example, if there are three lists - A, B, & C - containing five nodes
        /// each, edges are added between the following nodes:
        /// A[n] -> B[n+1]
        /// B[n] -> C[n+1]
        /// A[n] -> C[n+1]
        /// A[n+1] -> B[n+2]
        /// B[n+1] -> C[n+2]
        /// A[n+1] -> C[n+2]
        /// etc.
        /// And new paths are created for each - oh what fun.
        /// </summary>
        private void CrossLinkAsNodeLayers()
        {
            try
            {
                foreach (var asNumber in this.autonomousSystemNodeLayers.Keys)
                {
                    var layers = this.autonomousSystemNodeLayers[asNumber];
                    for (int layerIndex = 0; layerIndex < layers.Count; layerIndex++)
                    {
                        if (layerIndex == layers.Count - 1)
                        {
                            break;
                        }

                        CreateEdgesBetweenLayers(layers[layerIndex], layers[layerIndex + 1]);
                    }

                    for (int layerIndex = layers.Count - 1; layerIndex > 0; layerIndex--)
                    {
                        CreateEdgesBetweenLayers(layers[layerIndex], layers[layerIndex - 1]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CreateEdgesBetweenLayers(List<Device> layerA, List<Device> layerB)
        {
            try
            {
                for (int nodeIndex = 0; nodeIndex < layerA.Count; nodeIndex++)
                {
                    if (nodeIndex + 1 > layerB.Count - 1)
                    {
                        break;
                    }

                    // Add some randomness so that some links get skipped
                    if (this.faker.Random.Int(0, 7) > 5)
                    {
                        continue;
                    }

                    var aNode = layerA[nodeIndex];
                    var bNode = layerB[nodeIndex + 1];
                    ConnectDevices(aNode, bNode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string CreateRandomIpAddress(string subNet = "", bool isPrivate = false, int subnets = 4)
        {
            var classes = new List<string>();
            try
            {
                if (isPrivate)
                {
                    subNet = "10,172.16,192.168".Split(',')[this.faker.Random.Number(2)];
                }

                if (!String.IsNullOrEmpty(subNet))
                {
                    classes.AddRange(subNet.Split('.'));
                }

                while (classes.Count < 4)
                {
                    int nextValue = (classes.Count >= subnets ? 0 : this.faker.Random.Int(11, 254));
                    classes.Add(nextValue.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return String.Join(".", classes.ToArray());
        }

        private string CreateRandomDomainName(string ipAddress, string domainName = "")
        {
            try
            {
                if (domainName.Length == 0)
                {
                    domainName = this.faker.Internet.DomainName();
                }

                var parts = new List<string>();
                if (this.faker.Random.Int(1, 3) == 1)
                {
                    parts.Add(ipAddress.Replace('.', '-'));
                }
                else
                {
                    int maxParts = this.faker.Random.Int(1, 4);
                    for (int i = 0; i < maxParts; i++)
                    {
                        string text = $"{this.faker.Random.String(2, 'a', 'z')}-{this.faker.Random.Int(0, 9)}{this.faker.Random.Int(0, 9)}";
                        parts.Add(text);
                    }
                }

                parts.Add(domainName);
                return String.Join(".", parts.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return String.Empty;
        }
    }
}
