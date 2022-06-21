#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads](index.md#SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads').[WorkloadDefinition](WorkloadDefinition.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadDefinition')

## WorkloadDefinition(string[]) Constructor

Defines the workload response using multiple segments  
having the following format:  
TotalIntervals@Rate  
For example, 5@0.5 describes a segment that is 5 intervals long  
and increases at a rate of 0.5 percent per interval.  
Alternately, an absolute ending worklevel can be given using the syntax  
TotalIntervals>WorkLevel

```csharp
public WorkloadDefinition(params string[] segmentDefinitions);
```
#### Parameters

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadDefinition.WorkloadDefinition(string[]).segmentDefinitions'></a>

`segmentDefinitions` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')