#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.InternetGenerator](index.md#SolarWinds.Tools.ModelGenerators.InternetGenerator 'SolarWinds.Tools.ModelGenerators.InternetGenerator').[IDeviceComponent&lt;TMetricData&gt;](IDeviceComponent_TMetricData_.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>')

## IDeviceComponent<TMetricData>.GenerateObservation(DateTime, TimeRange, WorkWeek, double) Method

Generates and records observation for the component based on the workWeek workLevel. WorkLevelAffect  
controls the degree to which the worklevel affects the metric

```csharp
double GenerateObservation(System.DateTime interval, SolarWinds.Tools.ModelGenerators.Metrics.TimeRange timaRange, SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek workLevel, double workLevelAffect=1.0);
```
#### Parameters

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent_TMetricData_.GenerateObservation(System.DateTime,SolarWinds.Tools.ModelGenerators.Metrics.TimeRange,SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek,double).interval'></a>

`interval` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent_TMetricData_.GenerateObservation(System.DateTime,SolarWinds.Tools.ModelGenerators.Metrics.TimeRange,SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek,double).timaRange'></a>

`timaRange` [TimeRange](TimeRange.md 'SolarWinds.Tools.ModelGenerators.Metrics.TimeRange')

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent_TMetricData_.GenerateObservation(System.DateTime,SolarWinds.Tools.ModelGenerators.Metrics.TimeRange,SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek,double).workLevel'></a>

`workLevel` [WorkWeek](WorkWeek.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek')

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent_TMetricData_.GenerateObservation(System.DateTime,SolarWinds.Tools.ModelGenerators.Metrics.TimeRange,SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek,double).workLevelAffect'></a>

`workLevelAffect` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')