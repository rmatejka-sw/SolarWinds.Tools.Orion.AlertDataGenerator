#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.Metrics](index.md#SolarWinds.Tools.ModelGenerators.Metrics 'SolarWinds.Tools.ModelGenerators.Metrics').[AnomalyGenerator](AnomalyGenerator.md 'SolarWinds.Tools.ModelGenerators.Metrics.AnomalyGenerator')

## AnomalyGenerator.NextValue(bool) Method

Returns next anomalous value in a sequence. If sequence has completed and  
start is false, null is returned. Once the sequence has been started, start  
is ignored.

```csharp
public System.Nullable<double> NextValue(bool start=false);
```
#### Parameters

<a name='SolarWinds.Tools.ModelGenerators.Metrics.AnomalyGenerator.NextValue(bool).start'></a>

`start` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')