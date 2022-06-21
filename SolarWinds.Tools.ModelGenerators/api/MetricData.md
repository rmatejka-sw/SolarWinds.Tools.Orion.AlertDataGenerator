#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.Metrics](index.md#SolarWinds.Tools.ModelGenerators.Metrics 'SolarWinds.Tools.ModelGenerators.Metrics')

## MetricData Class

Used to represent faked metric data for a single point in time. All values will be consistent  
(Current and average will never be greater or less than max and min respectively).

```csharp
public abstract class MetricData :
SolarWinds.Tools.ModelGenerators.Metrics.IMetricData
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; MetricData

Derived  
&#8627; [CapacityMetricData](CapacityMetricData.md 'SolarWinds.Tools.ModelGenerators.Metrics.CapacityMetricData')

Implements [IMetricData](IMetricData.md 'SolarWinds.Tools.ModelGenerators.Metrics.IMetricData')