#### [SolarWinds.Tools.CommandLineTool](index.md 'index')
### [SolarWinds.Tools.CommandLineTool](index.md#SolarWinds.Tools.CommandLineTool 'SolarWinds.Tools.CommandLineTool').[CommandLineTool&lt;TOptions&gt;](CommandLineTool_TOptions_.md 'SolarWinds.Tools.CommandLineTool.CommandLineTool<TOptions>')

## CommandLineTool<TOptions>.GenerateIntervalData(DateTime) Method

Called once per every interval as defined in ITimeRangeOptions. For example, -pastdays 5 and  
-PollingInterval 10 minutes would result in 5*24*60/10= 720 calls to this method with the time  
going from Now to 5 days in the past. Client should override to provide their implementation.

```csharp
protected virtual int GenerateIntervalData(System.DateTime intervalTime);
```
#### Parameters

<a name='SolarWinds.Tools.CommandLineTool.CommandLineTool_TOptions_.GenerateIntervalData(System.DateTime).intervalTime'></a>

`intervalTime` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

DateTime for which data should be generated.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Integer as defined by the client.