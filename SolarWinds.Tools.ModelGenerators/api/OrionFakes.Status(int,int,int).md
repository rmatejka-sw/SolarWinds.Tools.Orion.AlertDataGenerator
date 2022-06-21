#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.Fakes](index.md#SolarWinds.Tools.ModelGenerators.Fakes 'SolarWinds.Tools.ModelGenerators.Fakes').[OrionFakes](OrionFakes.md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes')

## OrionFakes.Status(int, int, int) Method

Returns a fake Orion status based on the supplied percentages

```csharp
public SolarWinds.Tools.ModelGenerators.Fakes.OrionStatusInfo Status(int percentDown=2, int percentWarning=10, int percentOther=20);
```
#### Parameters

<a name='SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.Status(int,int,int).percentDown'></a>

`percentDown` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Percent of time Down (2) will be generated. Default is 2%.

<a name='SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.Status(int,int,int).percentWarning'></a>

`percentWarning` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Percent of time Warning (3) will be generated. Default is 10%.

<a name='SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.Status(int,int,int).percentOther'></a>

`percentOther` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Percent of time a status between 4 and 30 will be generated. Default is 20%.

#### Returns
[SolarWinds.Tools.ModelGenerators.Fakes.OrionStatusInfo](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.ModelGenerators.Fakes.OrionStatusInfo 'SolarWinds.Tools.ModelGenerators.Fakes.OrionStatusInfo')  
Orion integer status