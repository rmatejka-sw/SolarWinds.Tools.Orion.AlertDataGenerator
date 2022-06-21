#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads](index.md#SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads')

## WorkloadDefinition Class

```csharp
public class WorkloadDefinition
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; WorkloadDefinition

| Constructors | |
| :--- | :--- |
| [WorkloadDefinition(string[])](WorkloadDefinition.WorkloadDefinition(string[]).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadDefinition.WorkloadDefinition(string[])') | Defines the workload response using multiple segments<br/>having the following format:<br/>TotalIntervals@Rate<br/>For example, 5@0.5 describes a segment that is 5 intervals long<br/>and increases at a rate of 0.5 percent per interval.<br/>Alternately, an absolute ending worklevel can be given using the syntax<br/>TotalIntervals>WorkLevel |

| Methods | |
| :--- | :--- |
| [WorkloadLevels(double, Nullable&lt;int&gt;, int)](WorkloadDefinition.WorkloadLevels(double,Nullable_int_,int).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadDefinition.WorkloadLevels(double, System.Nullable<int>, int)') | Returns WorkLevel between 0 and 100 |
| [WorkloadRates(double)](WorkloadDefinition.WorkloadRates(double).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadDefinition.WorkloadRates(double)') | Enumerable for WorkloadRates returning value between 0 and 100 representing workload rate of change for the interval |
