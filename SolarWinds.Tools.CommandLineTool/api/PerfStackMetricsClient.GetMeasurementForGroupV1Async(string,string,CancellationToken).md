#### [SolarWinds.Tools.CommandLineTool](index.md 'index')
### [SolarWinds.Tools.CommandLineTool.Service.PerfStackClient](index.md#SolarWinds.Tools.CommandLineTool.Service.PerfStackClient 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient').[PerfStackMetricsClient](PerfStackMetricsClient.md 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackMetricsClient')

## PerfStackMetricsClient.GetMeasurementForGroupV1Async(string, string, CancellationToken) Method

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Metric>> GetMeasurementForGroupV1Async(string entityId, string groupId, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackMetricsClient.GetMeasurementForGroupV1Async(string,string,System.Threading.CancellationToken).entityId'></a>

`entityId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackMetricsClient.GetMeasurementForGroupV1Async(string,string,System.Threading.CancellationToken).groupId'></a>

`groupId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackMetricsClient.GetMeasurementForGroupV1Async(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used by other objects or threads to receive notice of cancellation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.ICollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')[SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Metric](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Metric 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Metric')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

#### Exceptions

[SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException')  
A server side error occurred.