#### [SolarWinds.Tools.CommandLineTool](index.md 'index')
### [SolarWinds.Tools.CommandLineTool.Service.PerfStackClient](index.md#SolarWinds.Tools.CommandLineTool.Service.PerfStackClient 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient').[PerfStackMetadataClient](PerfStackMetadataClient.md 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackMetadataClient')

## PerfStackMetadataClient.GetEntityGroupsMetricsMetadataV1Async(string, CancellationToken) Method

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.EntityType>> GetEntityGroupsMetricsMetadataV1Async(string entityTypeCdl, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackMetadataClient.GetEntityGroupsMetricsMetadataV1Async(string,System.Threading.CancellationToken).entityTypeCdl'></a>

`entityTypeCdl` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackMetadataClient.GetEntityGroupsMetricsMetadataV1Async(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used by other objects or threads to receive notice of cancellation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.ICollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')[SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.EntityType](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.EntityType 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.EntityType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

#### Exceptions

[SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException')  
A server side error occurred.