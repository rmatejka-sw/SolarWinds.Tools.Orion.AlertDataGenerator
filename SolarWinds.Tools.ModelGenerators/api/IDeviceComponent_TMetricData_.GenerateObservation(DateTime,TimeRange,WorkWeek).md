#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.InternetGenerator](index.md#SolarWinds.Tools.ModelGenerators.InternetGenerator 'SolarWinds.Tools.ModelGenerators.InternetGenerator').[IDeviceComponent&lt;TMetricData&gt;](IDeviceComponent_TMetricData_.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>')

## IDeviceComponent<TMetricData>.GenerateObservation(DateTime, TimeRange, WorkWeek) Method

Generates and records observation for the component based on the workWeek workLevel

```csharp
void GenerateObservation(System.DateTime interval, SolarWinds.Tools.CommandLineTool.Models.TimeRange timaRange, SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek workLevel);
```
#### Parameters

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent_TMetricData_.GenerateObservation(System.DateTime,SolarWinds.Tools.CommandLineTool.Models.TimeRange,SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek).interval'></a>

`interval` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent_TMetricData_.GenerateObservation(System.DateTime,SolarWinds.Tools.CommandLineTool.Models.TimeRange,SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek).timaRange'></a>

`timaRange` [SolarWinds.Tools.CommandLineTool.Models.TimeRange](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.Models.TimeRange 'SolarWinds.Tools.CommandLineTool.Models.TimeRange')

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent_TMetricData_.GenerateObservation(System.DateTime,SolarWinds.Tools.CommandLineTool.Models.TimeRange,SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek).workLevel'></a>

`workLevel` [SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek')