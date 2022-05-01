#### [SolarWinds.Tools.CommandLineTool](index.md 'index')
### [SolarWinds.Tools.CommandLineTool.Service.MapsClient](index.md#SolarWinds.Tools.CommandLineTool.Service.MapsClient 'SolarWinds.Tools.CommandLineTool.Service.MapsClient').[MapsAssetsClient](MapsAssetsClient.md 'SolarWinds.Tools.CommandLineTool.Service.MapsClient.MapsAssetsClient')

## MapsAssetsClient.GetMapsImageListAsync(AssetType, CancellationToken) Method

```csharp
public virtual System.Threading.Tasks.Task<System.Collections.Generic.ICollection<SolarWinds.Tools.CommandLineTool.Service.MapsClient.ImageFile>> GetMapsImageListAsync(SolarWinds.Tools.CommandLineTool.Service.MapsClient.AssetType assetType, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='SolarWinds.Tools.CommandLineTool.Service.MapsClient.MapsAssetsClient.GetMapsImageListAsync(SolarWinds.Tools.CommandLineTool.Service.MapsClient.AssetType,System.Threading.CancellationToken).assetType'></a>

`assetType` [SolarWinds.Tools.CommandLineTool.Service.MapsClient.AssetType](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.MapsClient.AssetType 'SolarWinds.Tools.CommandLineTool.Service.MapsClient.AssetType')

<a name='SolarWinds.Tools.CommandLineTool.Service.MapsClient.MapsAssetsClient.GetMapsImageListAsync(SolarWinds.Tools.CommandLineTool.Service.MapsClient.AssetType,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

A cancellation token that can be used by other objects or threads to receive notice of cancellation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.ICollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')[SolarWinds.Tools.CommandLineTool.Service.MapsClient.ImageFile](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.MapsClient.ImageFile 'SolarWinds.Tools.CommandLineTool.Service.MapsClient.ImageFile')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

#### Exceptions

[SolarWinds.Tools.CommandLineTool.Service.MapsClient.ApiException](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Service.MapsClient.ApiException 'SolarWinds.Tools.CommandLineTool.Service.MapsClient.ApiException')  
A server side error occurred.