#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.Fakes](index.md#SolarWinds.Tools.ModelGenerators.Fakes 'SolarWinds.Tools.ModelGenerators.Fakes').[OrionFakes](OrionFakes.md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes')

## OrionFakes.Memory(string, Nullable<DateTime>) Method

Returns CapacityMetricData representing machine memory. Value will be unique if machineId is null.  
If machineId is passed, previous value will be returned with updated values for MetricData while  
Capacity will remain unchanged. If a pollingInterval is included, new data will be generated on first call  
but subsequent calls for the same interval will return the data unchanged.

```csharp
public SolarWinds.Tools.ModelGenerators.Metrics.MemoryMetricData Memory(string machineId=null, System.Nullable<System.DateTime> pollingInterval=null);
```
#### Parameters

<a name='SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.Memory(string,System.Nullable_System.DateTime_).machineId'></a>

`machineId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Unique identifier for machine for which faked memory is used.

<a name='SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.Memory(string,System.Nullable_System.DateTime_).pollingInterval'></a>

`pollingInterval` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Polling interval for data. If called again with same machineId and pollingInterval, no changes will be made to previous data.

#### Returns
[SolarWinds.Tools.ModelGenerators.Metrics.MemoryMetricData](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.ModelGenerators.Metrics.MemoryMetricData 'SolarWinds.Tools.ModelGenerators.Metrics.MemoryMetricData')  
CapacityMetricData with faked, consistent values.