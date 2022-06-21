#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.Fakes](index.md#SolarWinds.Tools.ModelGenerators.Fakes 'SolarWinds.Tools.ModelGenerators.Fakes').[OrionFakes](OrionFakes.md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes')

## OrionFakes.StatusImage(Nullable<int>) Method

Orion status image filename based on existing status if fromStatus passed or random by default.

```csharp
public string StatusImage(System.Nullable<int> fromStatus=null);
```
#### Parameters

<a name='SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.StatusImage(System.Nullable_int_).fromStatus'></a>

`fromStatus` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Pass to get image for existing status

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Filename for image status