#### [SolarWinds.Tools.CommandLineTool](index.md 'index')
### [SolarWinds.Tools.CommandLineTool.Service.PerfStackClient](index.md#SolarWinds.Tools.CommandLineTool.Service.PerfStackClient 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient').[PerfStackMetricsClient](PerfStackMetricsClient.md 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackMetricsClient')

## PerfStackMetricsClient.GetMeasurementForEntityMetricId2Async(string, MeasurementForEntityRequest, CancellationToken) Method

```csharp
public System.Threading.Tasks.Task<SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Metric> GetMeasurementForEntityMetricId2Async(string id, SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.MeasurementForEntityRequest request, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackMetricsClient.GetMeasurementForEntityMetricId2Async(string,SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.MeasurementForEntityRequest,System.Threading.CancellationToken).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackMetricsClient.GetMeasurementForEntityMetricId2Async(string,SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.MeasurementForEntityRequest,System.Threading.CancellationToken).request'></a>

`request` [SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.MeasurementForEntityRequest](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.MeasurementForEntityRequest 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.MeasurementForEntityRequest')

<a name='SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackMetricsClient.GetMeasurementForEntityMetricId2Async(string,SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.MeasurementForEntityRequest,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used by other objects or threads to receive notice of cancellation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Metric](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Metric 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Metric')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

#### Exceptions

[SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException')  
A server side error occurred.