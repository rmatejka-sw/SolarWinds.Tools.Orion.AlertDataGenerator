#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.InternetGenerator](index.md#SolarWinds.Tools.ModelGenerators.InternetGenerator 'SolarWinds.Tools.ModelGenerators.InternetGenerator')

## InternetNetworkGenerator Class

Adapted from  
https://github.com/solarwinds/orion/blob/main/src/libs/tests/SolarWinds.NetPath/SolarWinds.NetPath.Test.Common/TraceRouteGraphGenerator.cs  
Generates a connected set of network Devices representing a typical Internet topology where a path  
is connected through one or more Autonomous Systems (AS) which have their own internal structure. Each Device can have  
one ore more DeviceInterfaces with correctly defined Internet subnet that connects it to  the next network. The  
connections between networks are tracked as DeviceConnections.

```csharp
public class InternetNetworkGenerator
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; InternetNetworkGenerator

| Properties | |
| :--- | :--- |
| [DeviceConnections](InternetNetworkGenerator.DeviceConnections.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator.DeviceConnections') | List of DeviceConnections between one DeviceInterface and a second DeviceConnection. |
| [DeviceInterfaces](InternetNetworkGenerator.DeviceInterfaces.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator.DeviceInterfaces') | List of all DeviceInterfaces utilized in defining the Internet network as any associated intranets. |
| [Devices](InternetNetworkGenerator.Devices.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator.Devices') | List of all Devices comprising the Internet network. |
| [TotalNetworks](InternetNetworkGenerator.TotalNetworks.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator.TotalNetworks') | Total number of networks created where each network is defined by multiple paths between a starting<br/>and terminating device. All networks are then connected together into a complete Internet. |

| Methods | |
| :--- | :--- |
| [CreateNetworks()](InternetNetworkGenerator.CreateNetworks().md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator.CreateNetworks()') | Uses IInternetGeneratorOptions to generate a complete network of connected devices with accurate subnet definitions and<br/>redundant path definitions between start and endpoints. |
