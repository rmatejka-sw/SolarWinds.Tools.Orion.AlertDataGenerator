#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.Metrics](index.md#SolarWinds.Tools.ModelGenerators.Metrics 'SolarWinds.Tools.ModelGenerators.Metrics')

## IMetricData Interface

```csharp
public interface IMetricData
```

Derived  
&#8627; [MetricData](MetricData.md 'SolarWinds.Tools.ModelGenerators.Metrics.MetricData')

| Methods | |
| :--- | :--- |
| [RestoreTo(DateTime, TimeRange)](IMetricData.RestoreTo(DateTime,TimeRange).md 'SolarWinds.Tools.ModelGenerators.Metrics.IMetricData.RestoreTo(System.DateTime, SolarWinds.Tools.ModelGenerators.Metrics.TimeRange)') | Restores historic Metric date from the requested polling interval.<br/>NOTE: Current value is set to historic value. Call RestoreToLatest |
| [RestoreToLatest()](IMetricData.RestoreToLatest().md 'SolarWinds.Tools.ModelGenerators.Metrics.IMetricData.RestoreToLatest()') | Restores current value to the value prior to calling<br/>RestoreTo and returns the current value. If Restore was not called,<br/>returns the current value. |
