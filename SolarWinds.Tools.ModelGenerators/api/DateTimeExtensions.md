#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.Extensions](index.md#SolarWinds.Tools.ModelGenerators.Extensions 'SolarWinds.Tools.ModelGenerators.Extensions')

## DateTimeExtensions Class

```csharp
public static class DateTimeExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DateTimeExtensions

| Methods | |
| :--- | :--- |
| [ToPollingInterval(this DateTime, TimeSpan, RoundDirection)](DateTimeExtensions.ToPollingInterval(thisDateTime,TimeSpan,RoundDirection).md 'SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.ToPollingInterval(this System.DateTime, System.TimeSpan, SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.RoundDirection)') | Returns new DateTime that has been normalized to a time aligned with the start of the hour.<br/>For example, if passed 1/1/2020 1:15am, for a 10 minutes polling interval, returns 1/1/2020 1:20am. |
| [ToTimeInterval(this DateTime, TimeSpan)](DateTimeExtensions.ToTimeInterval(thisDateTime,TimeSpan).md 'SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.ToTimeInterval(this System.DateTime, System.TimeSpan)') | Takes a DateTime and rounds to the interval start time if the time<br/>is less than the normalized start time (e.g., 5, 10, 15 for 5 minute<br/>interval span) |
| [ToTimeIntervalIndex(this DateTime, TimeRange, int)](DateTimeExtensions.ToTimeIntervalIndex(thisDateTime,TimeRange,int).md 'SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.ToTimeIntervalIndex(this System.DateTime, SolarWinds.Tools.ModelGenerators.Metrics.TimeRange, int)') | Returns the zero-based interval index date dateTime falls into<br/>for the specified TimeRange. If TimeRange is null, uses a default TimeRange<br/>of 24 hours with the first interval starting at midnight. |
