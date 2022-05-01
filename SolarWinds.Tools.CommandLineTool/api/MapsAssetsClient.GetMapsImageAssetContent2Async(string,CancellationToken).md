#### [SolarWinds.Tools.CommandLineTool](index.md 'index')
### [SolarWinds.Tools.CommandLineTool.Service.MapsClient](index.md#SolarWinds.Tools.CommandLineTool.Service.MapsClient 'SolarWinds.Tools.CommandLineTool.Service.MapsClient').[MapsAssetsClient](MapsAssetsClient.md 'SolarWinds.Tools.CommandLineTool.Service.MapsClient.MapsAssetsClient')

## MapsAssetsClient.GetMapsImageAssetContent2Async(string, CancellationToken) Method

```csharp
public virtual System.Threading.Tasks.Task<SolarWinds.Tools.CommandLineTool.Service.MapsClient.FileResponse> GetMapsImageAssetContent2Async(string assetId, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='SolarWinds.Tools.CommandLineTool.Service.MapsClient.MapsAssetsClient.GetMapsImageAssetContent2Async(string,System.Threading.CancellationToken).assetId'></a>

`assetId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='SolarWinds.Tools.CommandLineTool.Service.MapsClient.MapsAssetsClient.GetMapsImageAssetContent2Async(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used by other objects or threads to receive notice of cancellation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[SolarWinds.Tools.CommandLineTool.Service.MapsClient.FileResponse](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.MapsClient.FileResponse 'SolarWinds.Tools.CommandLineTool.Service.MapsClient.FileResponse')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

#### Exceptions

[SolarWinds.Tools.CommandLineTool.Service.MapsClient.ApiException](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.MapsClient.ApiException 'SolarWinds.Tools.CommandLineTool.Service.MapsClient.ApiException')  
A server side error occurred.