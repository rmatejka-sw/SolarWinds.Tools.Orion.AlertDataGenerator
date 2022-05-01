#### [SolarWinds.Tools.CommandLineTool](index.md 'index')
### [SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient](index.md#SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient').[SwisClient](SwisClient.md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient')

## SwisClient.QueryAsync(QueryParam, CancellationToken) Method

```csharp
public System.Threading.Tasks.Task<SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.DataTable> QueryAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.QueryParam query, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.QueryAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.QueryParam,System.Threading.CancellationToken).query'></a>

`query` [SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.QueryParam](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.QueryParam 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.QueryParam')

<a name='SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.QueryAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.QueryParam,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used by other objects or threads to receive notice of cancellation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.DataTable](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.DataTable 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.DataTable')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

#### Exceptions

[SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.ApiException](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.ApiException 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.ApiException')  
A server side error occurred.