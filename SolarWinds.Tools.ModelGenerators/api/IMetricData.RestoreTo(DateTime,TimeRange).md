#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.Metrics](index.md#SolarWinds.Tools.ModelGenerators.Metrics 'SolarWinds.Tools.ModelGenerators.Metrics').[IMetricData](IMetricData.md 'SolarWinds.Tools.ModelGenerators.Metrics.IMetricData')

## IMetricData.RestoreTo(DateTime, TimeRange) Method

Restores historic Metric date from the requested polling interval.  
NOTE: Current value is set to historic value. Call RestoreToLatest

```csharp
SolarWinds.Tools.ModelGenerators.Metrics.MetricDataObservation RestoreTo(System.DateTime pollingInterval, SolarWinds.Tools.ModelGenerators.Metrics.TimeRange timeRange);
```
#### Parameters

<a name='SolarWinds.Tools.ModelGenerators.Metrics.IMetricData.RestoreTo(System.DateTime,SolarWinds.Tools.ModelGenerators.Metrics.TimeRange).pollingInterval'></a>

`pollingInterval` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

<a name='SolarWinds.Tools.ModelGenerators.Metrics.IMetricData.RestoreTo(System.DateTime,SolarWinds.Tools.ModelGenerators.Metrics.TimeRange).timeRange'></a>

`timeRange` [TimeRange](TimeRange.md 'SolarWinds.Tools.ModelGenerators.Metrics.TimeRange')

#### Returns
[SolarWinds.Tools.ModelGenerators.Metrics.MetricDataObservation](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.ModelGenerators.Metrics.MetricDataObservation 'SolarWinds.Tools.ModelGenerators.Metrics.MetricDataObservation')