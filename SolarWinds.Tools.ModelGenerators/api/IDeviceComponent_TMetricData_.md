#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.InternetGenerator](index.md#SolarWinds.Tools.ModelGenerators.InternetGenerator 'SolarWinds.Tools.ModelGenerators.InternetGenerator')

## IDeviceComponent<TMetricData> Interface

An entity that is part of a device

```csharp
public interface IDeviceComponent<TMetricData>
    where TMetricData : SolarWinds.Tools.DataGeneration.Helpers.Fakes.IMetricData
```
#### Type parameters

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent_TMetricData_.TMetricData'></a>

`TMetricData`

| Properties | |
| :--- | :--- |
| [ComponentType](IDeviceComponent_TMetricData_.ComponentType.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>.ComponentType') | Type of component |
| [DeviceIndex](IDeviceComponent_TMetricData_.DeviceIndex.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>.DeviceIndex') | Global index of device which the component is a part of |

| Methods | |
| :--- | :--- |
| [GenerateObservation(DateTime, TimeRange, WorkWeek)](IDeviceComponent_TMetricData_.GenerateObservation(DateTime,TimeRange,WorkWeek).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>.GenerateObservation(System.DateTime, SolarWinds.Tools.CommandLineTool.Models.TimeRange, SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek)') | Generates and records observation for the component based on the workWeek workLevel |
