#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads](index.md#SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads')

## WorkloadSegment Class

Defines a single segment of a workload. The duration of the segment  
is defined in terms of polling intervals.

```csharp
public class WorkloadSegment
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; WorkloadSegment

| Constructors | |
| :--- | :--- |
| [WorkloadSegment(int, double)](WorkloadSegment.WorkloadSegment(int,double).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadSegment.WorkloadSegment(int, double)') | Defines a workload segment lasting totalIntervals and changing by<br/>percentChangePerInterval each interval. |
| [WorkloadSegment(int, double, double)](WorkloadSegment.WorkloadSegment(int,double,double).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadSegment.WorkloadSegment(int, double, double)') | Defines a workload segment lasting totalIntervals and from startPercent<br/>to endPercent. |
| [WorkloadSegment(string)](WorkloadSegment.WorkloadSegment(string).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadSegment.WorkloadSegment(string)') | Description of the segment having the following format:<br/>TotalIntervals@Rate<br/>For example, 5@0.5 describes a segment that is 5 intervals long<br/>and increases at a rate of 0.5 percent per interval.<br/>Alternately, an absolute ending worklevel can be given using the syntax<br/>TotalIntervals>WorkLevel |

| Methods | |
| :--- | :--- |
| [WorkloadLevels(double, Nullable&lt;int&gt;, int)](WorkloadSegment.WorkloadLevels(double,Nullable_int_,int).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadSegment.WorkloadLevels(double, System.Nullable<int>, int)') | Enumerable for WorkLevels returning value between 0 and 100 representing workload percentage |
| [WorkloadRates(double)](WorkloadSegment.WorkloadRates(double).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadSegment.WorkloadRates(double)') | Enumerable for WorkloadRates returning value between 0 and 100 representing workload rate of change for the interval |
