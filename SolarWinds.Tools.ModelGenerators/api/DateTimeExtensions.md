#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.Extensions](index.md#SolarWinds.Tools.ModelGenerators.Extensions 'SolarWinds.Tools.ModelGenerators.Extensions')

## DateTimeExtensions Class

```csharp
public static class DateTimeExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DateTimeExtensions

| Methods | |
| :--- | :--- |
| [ToTimeInterval(this DateTime, TimeSpan)](DateTimeExtensions.ToTimeInterval(thisDateTime,TimeSpan).md 'SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.ToTimeInterval(this System.DateTime, System.TimeSpan)') | Takes a DateTime and rounds to the interval start time if the time<br/>is less than the normalized start time (e.g., 5, 10, 15 for 5 minute<br/>interval span) |
| [ToTimeIntervalIndex(this DateTime, TimeRange, int)](DateTimeExtensions.ToTimeIntervalIndex(thisDateTime,TimeRange,int).md 'SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.ToTimeIntervalIndex(this System.DateTime, SolarWinds.Tools.CommandLineTool.Models.TimeRange, int)') | Returns the zero-based interval index date dateTime falls into<br/>for the specified TimeRange. If TimeRange is null, uses a default TimeRange<br/>of 24 hours with the first interval starting at midnight. |
