#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.InternetGenerator](index.md#SolarWinds.Tools.ModelGenerators.InternetGenerator 'SolarWinds.Tools.ModelGenerators.InternetGenerator')

## IDeviceComponent<TMetricData> Interface

An entity that is part of a device

```csharp
public interface IDeviceComponent<TMetricData>
    where TMetricData : SolarWinds.Tools.ModelGenerators.Metrics.IMetricData
```
#### Type parameters

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent_TMetricData_.TMetricData'></a>

`TMetricData`

| Properties | |
| :--- | :--- |
| [ComponentType](IDeviceComponent_TMetricData_.ComponentType.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>.ComponentType') | Type of component |
| [Current](IDeviceComponent_TMetricData_.Current.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>.Current') | Returns the current reading for the MetricData. Equivalent to<br/>MetricData.Current |
| [DeviceIndex](IDeviceComponent_TMetricData_.DeviceIndex.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>.DeviceIndex') | Global index of device which the component is a part of |

| Methods | |
| :--- | :--- |
| [GenerateObservation(DateTime, TimeRange, WorkWeek, double)](IDeviceComponent_TMetricData_.GenerateObservation(DateTime,TimeRange,WorkWeek,double).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>.GenerateObservation(System.DateTime, SolarWinds.Tools.ModelGenerators.Metrics.TimeRange, SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek, double)') | Generates and records observation for the component based on the workWeek workLevel. WorkLevelAffect<br/>controls the degree to which the worklevel affects the metric |
