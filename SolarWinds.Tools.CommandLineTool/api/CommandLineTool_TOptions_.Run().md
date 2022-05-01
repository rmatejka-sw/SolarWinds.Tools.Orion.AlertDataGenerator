#### [SolarWinds.Tools.CommandLineTool](index.md 'index')
### [SolarWinds.Tools.CommandLineTool](index.md#SolarWinds.Tools.CommandLineTool 'SolarWinds.Tools.CommandLineTool').[CommandLineTool&lt;TOptions&gt;](CommandLineTool_TOptions_.md 'SolarWinds.Tools.CommandLineTool.CommandLineTool<TOptions>')

## CommandLineTool<TOptions>.Run() Method

Validates command line options, connects to SQl Server, and then begins calling GenerateIntervalData  
for the total number of times determined from the ITimeRangeOptions.

```csharp
protected virtual SolarWinds.Tools.CommandLineTool.RunStatus Run();
```

#### Returns
[SolarWinds.Tools.CommandLineTool.RunStatus](https://docs.microsoft.com/en-us/dotnet/api/SolarWinds.Tools.CommandLineTool.RunStatus 'SolarWinds.Tools.CommandLineTool.RunStatus')  
Status of run