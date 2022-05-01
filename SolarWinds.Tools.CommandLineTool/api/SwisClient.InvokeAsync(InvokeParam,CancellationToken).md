#### [SolarWinds.Tools.CommandLineTool](index.md 'index')
### [SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient](index.md#SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient').[SwisClient](SwisClient.md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient')

## SwisClient.InvokeAsync(InvokeParam, CancellationToken) Method

```csharp
public System.Threading.Tasks.Task<object> InvokeAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.InvokeParam verb, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.InvokeAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.InvokeParam,System.Threading.CancellationToken).verb'></a>

`verb` [SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.InvokeParam](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.InvokeParam 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.InvokeParam')

<a name='SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.InvokeAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.InvokeParam,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used by other objects or threads to receive notice of cancellation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

#### Exceptions

[SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.ApiException](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.ApiException 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.ApiException')  
A server side error occurred.