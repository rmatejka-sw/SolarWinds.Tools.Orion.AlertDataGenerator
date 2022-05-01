#### [SolarWinds.Tools.CommandLineTool](index.md 'index')
### [SolarWinds.Tools.CommandLineTool.Service.PerfStackClient](index.md#SolarWinds.Tools.CommandLineTool.Service.PerfStackClient 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient').[PerfStackEntitiesClient](PerfStackEntitiesClient.md 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackEntitiesClient')

## PerfStackEntitiesClient.GetRelationshipsForEntityAsync(string, CancellationToken) Method

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Entity>> GetRelationshipsForEntityAsync(string entityIdsCdl, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackEntitiesClient.GetRelationshipsForEntityAsync(string,System.Threading.CancellationToken).entityIdsCdl'></a>

`entityIdsCdl` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackEntitiesClient.GetRelationshipsForEntityAsync(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used by other objects or threads to receive notice of cancellation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.ICollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')[SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Entity](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Entity 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

#### Exceptions

[SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException')  
A server side error occurred.