#### [SolarWinds.Tools.CommandLineTool](index.md 'index')
### [SolarWinds.Tools.CommandLineTool.Service.PerfStackClient](index.md#SolarWinds.Tools.CommandLineTool.Service.PerfStackClient 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient').[PerfStackProjectsClient](PerfStackProjectsClient.md 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackProjectsClient')

## PerfStackProjectsClient.GetPerfStackProjectAsync(string, CancellationToken) Method

```csharp
public System.Threading.Tasks.Task<SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ProjectResponse> GetPerfStackProjectAsync(string projectIdsCdl, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackProjectsClient.GetPerfStackProjectAsync(string,System.Threading.CancellationToken).projectIdsCdl'></a>

`projectIdsCdl` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.PerfStackProjectsClient.GetPerfStackProjectAsync(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used by other objects or threads to receive notice of cancellation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ProjectResponse](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ProjectResponse 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ProjectResponse')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

#### Exceptions

[SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException 'SolarWinds.Tools.CommandLineTool.Service.PerfStackClient.ApiException')  
A server side error occurred.