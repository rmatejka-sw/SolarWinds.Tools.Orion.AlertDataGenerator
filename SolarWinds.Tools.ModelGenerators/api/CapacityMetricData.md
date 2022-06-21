#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.Metrics](index.md#SolarWinds.Tools.ModelGenerators.Metrics 'SolarWinds.Tools.ModelGenerators.Metrics')

## CapacityMetricData Class

Represents Metric Data that has a physical capacity like memory, disk space,  
and bandwidth. Base MetricData will be bounded by the Capacity.

```csharp
public abstract class CapacityMetricData : SolarWinds.Tools.ModelGenerators.Metrics.MetricData,
SolarWinds.Tools.ModelGenerators.Metrics.ICapacity
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [MetricData](MetricData.md 'SolarWinds.Tools.ModelGenerators.Metrics.MetricData') &#129106; CapacityMetricData

Implements [SolarWinds.Tools.ModelGenerators.Metrics.ICapacity](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.ModelGenerators.Metrics.ICapacity 'SolarWinds.Tools.ModelGenerators.Metrics.ICapacity')

| Properties | |
| :--- | :--- |
| [PhysicalCapacities](CapacityMetricData.PhysicalCapacities.md 'SolarWinds.Tools.ModelGenerators.Metrics.CapacityMetricData.PhysicalCapacities') | List of typical capacities for the associated physical device. For example,<br/>disk drives could be 500MB, 1TB, 2TB, etc. |
