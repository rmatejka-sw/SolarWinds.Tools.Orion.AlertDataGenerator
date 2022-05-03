#### [SolarWinds.Tools.ModelGenerators](index.md 'index')

## SolarWinds.Tools.ModelGenerators Assembly
### Namespaces

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator'></a>

## SolarWinds.Tools.ModelGenerators.InternetGenerator Namespace
- **[InternetNetworkGenerator](InternetNetworkGenerator.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator')** `Class` Adapted from  
  https://github.com/solarwinds/orion/blob/main/src/libs/tests/SolarWinds.NetPath/SolarWinds.NetPath.Test.Common/TraceRouteGraphGenerator.cs  
  Generates a connected set of network Devices representing a typical Internet topology where a path  
  is connected through one or more Autonomous Systems (AS) which have their own internal structure. Each Device can have  
  one ore more DeviceInterfaces with correctly defined Internet subnet that connects it to  the next network. The  
  connections between networks are tracked as DeviceConnections.
  - **[DeviceConnections](InternetNetworkGenerator.DeviceConnections.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator.DeviceConnections')** `Property` List of DeviceConnections between one DeviceInterface and a second DeviceConnection.
  - **[DeviceInterfaces](InternetNetworkGenerator.DeviceInterfaces.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator.DeviceInterfaces')** `Property` List of all DeviceInterfaces utilized in defining the Internet network as any associated intranets.
  - **[Devices](InternetNetworkGenerator.Devices.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator.Devices')** `Property` List of all Devices comprising the Internet network.
  - **[TotalNetworks](InternetNetworkGenerator.TotalNetworks.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator.TotalNetworks')** `Property` Total number of networks created where each network is defined by multiple paths between a starting  
    and terminating device. All networks are then connected together into a complete Internet.
  - **[CreateNetworks()](InternetNetworkGenerator.CreateNetworks().md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator.CreateNetworks()')** `Method` Uses IInternetGeneratorOptions to generate a complete network of connected devices with accurate subnet definitions and  
    redundant path definitions between start and endpoints.

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator.Options'></a>

## SolarWinds.Tools.ModelGenerators.InternetGenerator.Options Namespace
- **[IInternetGeneratorOptions](IInternetGeneratorOptions.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.Options.IInternetGeneratorOptions')** `Interface` Options for generating a topology typical of the Internet.