#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads](index.md#SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads')

## DeviceWorkload Class

Represents a specific type of work that is done on a device which can impact the device  
memory, cpu, interface, and other component metrics. For example, workload for a backup task  
would affect cpu, memory, interface bandwidth, and volume space. Workload segments  are used to  
describe the overall shape or envelope for the workload over time. It is very similar to the concept of  
an Attack, Decay, Sustain, Release envelope used in waveform generation.

```csharp
public class DeviceWorkload
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DeviceWorkload

| Properties | |
| :--- | :--- |
| [ComponentAffects](DeviceWorkload.ComponentAffects.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.DeviceWorkload.ComponentAffects') | The components |
