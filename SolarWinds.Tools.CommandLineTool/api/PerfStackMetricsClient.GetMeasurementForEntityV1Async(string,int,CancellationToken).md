#### [SolarWinds.Tools.CommandLineTool](index.md 'index')
### [SolarWinds.Tools.CommandLineTool.Service.PerfStackClient](index.md#SolarWinds.Tools.CommandLineTool.Service.PerfStackClient 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient').[PerfStackMetricsClient](PerfStackMetricsClient.md 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackMetricsClient')

## PerfStackMetricsClient.GetMeasurementForEntityV1Async(string, int, CancellationToken) Method

```csharp
public System.Threading.Tasks.Task<SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Metric> GetMeasurementForEntityV1Async(string id, int limitationId, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackMetricsClient.GetMeasurementForEntityV1Async(string,int,System.Threading.CancellationToken).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackMetricsClient.GetMeasurementForEntityV1Async(string,int,System.Threading.CancellationToken).limitationId'></a>

`limitationId` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackMetricsClient.GetMeasurementForEntityV1Async(string,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used by other objects or threads to receive notice of cancellation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Metric](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Metric 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Metric')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

#### Exceptions

[SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException')  
A server side error occurred.