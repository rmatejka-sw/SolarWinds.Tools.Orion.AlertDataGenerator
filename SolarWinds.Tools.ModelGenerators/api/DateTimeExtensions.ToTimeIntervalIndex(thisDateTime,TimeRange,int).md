#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.Extensions](index.md#SolarWinds.Tools.ModelGenerators.Extensions 'SolarWinds.Tools.ModelGenerators.Extensions').[DateTimeExtensions](DateTimeExtensions.md 'SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions')

## DateTimeExtensions.ToTimeIntervalIndex(this DateTime, TimeRange, int) Method

Returns the zero-based interval index date dateTime falls into  
for the specified TimeRange. If TimeRange is null, uses a default TimeRange  
of 24 hours with the first interval starting at midnight.

```csharp
public static int ToTimeIntervalIndex(this System.DateTime dateTime, SolarWinds.Tools.CommandLineTool.Models.TimeRange timeRange=null, int minutesPerInterval=10);
```
#### Parameters

<a name='SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.ToTimeIntervalIndex(thisSystem.DateTime,SolarWinds.Tools.CommandLineTool.Models.TimeRange,int).dateTime'></a>

`dateTime` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

<a name='SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.ToTimeIntervalIndex(thisSystem.DateTime,SolarWinds.Tools.CommandLineTool.Models.TimeRange,int).timeRange'></a>

`timeRange` [SolarWinds.Tools.CommandLineTool.Models.TimeRange](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Models.TimeRange 'SolarWinds.Tools.CommandLineTool.Models.TimeRange')

<a name='SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.ToTimeIntervalIndex(thisSystem.DateTime,SolarWinds.Tools.CommandLineTool.Models.TimeRange,int).minutesPerInterval'></a>

`minutesPerInterval` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')