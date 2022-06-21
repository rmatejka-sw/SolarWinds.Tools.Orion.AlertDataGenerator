#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.Extensions](index.md#SolarWinds.Tools.ModelGenerators.Extensions 'SolarWinds.Tools.ModelGenerators.Extensions').[DateTimeExtensions](DateTimeExtensions.md 'SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions')

## DateTimeExtensions.ToTimeInterval(this DateTime, TimeSpan) Method

Takes a DateTime and rounds to the interval start time if the time  
is less than the normalized start time (e.g., 5, 10, 15 for 5 minute  
interval span)

```csharp
public static System.DateTime ToTimeInterval(this System.DateTime dateTime, System.TimeSpan intervalSpan);
```
#### Parameters

<a name='SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.ToTimeInterval(thisSystem.DateTime,System.TimeSpan).dateTime'></a>

`dateTime` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

<a name='SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.ToTimeInterval(thisSystem.DateTime,System.TimeSpan).intervalSpan'></a>

`intervalSpan` [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')

#### Returns
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')