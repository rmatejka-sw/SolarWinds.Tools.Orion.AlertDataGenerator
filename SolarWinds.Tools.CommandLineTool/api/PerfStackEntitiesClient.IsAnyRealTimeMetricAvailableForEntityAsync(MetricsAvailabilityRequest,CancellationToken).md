#### [SolarWinds.Tools.CommandLineTool](index.md 'index')
### [SolarWinds.Tools.CommandLineTool.Service.PerfStackClient](index.md#SolarWinds.Tools.CommandLineTool.Service.PerfStackClient 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient').[PerfStackEntitiesClient](PerfStackEntitiesClient.md 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackEntitiesClient')

## PerfStackEntitiesClient.IsAnyRealTimeMetricAvailableForEntityAsync(MetricsAvailabilityRequest, CancellationToken) Method

```csharp
public System.Threading.Tasks.Task<bool> IsAnyRealTimeMetricAvailableForEntityAsync(SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.MetricsAvailabilityRequest request, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackEntitiesClient.IsAnyRealTimeMetricAvailableForEntityAsync(SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.MetricsAvailabilityRequest,System.Threading.CancellationToken).request'></a>

`request` [SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.MetricsAvailabilityRequest](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.MetricsAvailabilityRequest 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.MetricsAvailabilityRequest')

<a name='SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackEntitiesClient.IsAnyRealTimeMetricAvailableForEntityAsync(SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.MetricsAvailabilityRequest,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used by other objects or threads to receive notice of cancellation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

#### Exceptions

[SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException')  
A server side error occurred.