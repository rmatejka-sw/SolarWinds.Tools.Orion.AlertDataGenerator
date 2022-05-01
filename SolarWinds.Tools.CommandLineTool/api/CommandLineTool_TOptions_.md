#### [SolarWinds.Tools.CommandLineTool](index.md 'index')
### [SolarWinds.Tools.CommandLineTool](index.md#SolarWinds.Tools.CommandLineTool 'SolarWinds.Tools.CommandLineTool')

## CommandLineTool<TOptions> Class

Provides common support for command-line application with focus on data-generation for Orion.  
Includes support for parsing command line options, Orion Authentication for WebApi access, and Orion  
SQL server access.

```csharp
public class CommandLineTool<TOptions>
    where TOptions : SolarWinds.Tools.CommandLineTool.Options.IDatabaseOptions, SolarWinds.Tools.CommandLineTool.Options.ITimeRangeOptions, SolarWinds.Tools.CommandLineTool.Options.IOrionOptions, new()
```
#### Type parameters

<a name='SolarWinds.Tools.CommandLineTool.CommandLineTool_TOptions_.TOptions'></a>

`TOptions`

Option class that implement can implement IDatabaseOptions, ITimeRangeOptions, and IOrionOptions  
            as required for your application. See AlertDataGeneratorOptions for example usage.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CommandLineTool<TOptions>

| Methods | |
| :--- | :--- |
| [GenerateIntervalData(DateTime)](CommandLineTool_TOptions_.GenerateIntervalData(DateTime).md 'SolarWinds.Tools.CommandLineTool.CommandLineTool<TOptions>.GenerateIntervalData(System.DateTime)') | Called once per every interval as defined in ITimeRangeOptions. For example, -pastdays 5 and<br/>-PollingInterval 10 minutes would result in 5*24*60/10= 720 calls to this method with the time<br/>going from Now to 5 days in the past. Client should override to provide their implementation. |
| [Run()](CommandLineTool_TOptions_.Run().md 'SolarWinds.Tools.CommandLineTool.CommandLineTool<TOptions>.Run()') | Validates command line options, connects to SQl Server, and then begins calling GenerateIntervalData<br/>for the total number of times determined from the ITimeRangeOptions. |
