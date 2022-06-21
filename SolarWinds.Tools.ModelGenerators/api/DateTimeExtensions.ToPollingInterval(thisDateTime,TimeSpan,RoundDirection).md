#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.Extensions](index.md#SolarWinds.Tools.ModelGenerators.Extensions 'SolarWinds.Tools.ModelGenerators.Extensions').[DateTimeExtensions](DateTimeExtensions.md 'SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions')

## DateTimeExtensions.ToPollingInterval(this DateTime, TimeSpan, RoundDirection) Method

Returns new DateTime that has been normalized to a time aligned with the start of the hour.  
For example, if passed 1/1/2020 1:15am, for a 10 minutes polling interval, returns 1/1/2020 1:20am.

```csharp
public static System.DateTime ToPollingInterval(this System.DateTime date, System.TimeSpan pollingInterval, SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.RoundDirection roundDirection);
```
#### Parameters

<a name='SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.ToPollingInterval(thisSystem.DateTime,System.TimeSpan,SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.RoundDirection).date'></a>

`date` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

Date to be normalized

<a name='SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.ToPollingInterval(thisSystem.DateTime,System.TimeSpan,SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.RoundDirection).pollingInterval'></a>

`pollingInterval` [System.TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/System.TimeSpan 'System.TimeSpan')

Time between polls

<a name='SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.ToPollingInterval(thisSystem.DateTime,System.TimeSpan,SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.RoundDirection).roundDirection'></a>

`roundDirection` [SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.RoundDirection](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.RoundDirection 'SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.RoundDirection')

Direction to round date.

#### Returns
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
DateTime rounded up to next polling interval