#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.InternetGenerator.BusinessProcesses](index.md#SolarWinds.Tools.ModelGenerators.InternetGenerator.BusinessProcesses 'SolarWinds.Tools.ModelGenerators.InternetGenerator.BusinessProcesses')

## BusinessProcess Class

A business process represents a collection of work that happens over time. The work is measured  
as a WorkLevel ranging from 0 to 100%. The cycle is used to schedule DeviceWorkloads to specific devices  
over time to represent activity on devices.

```csharp
public class BusinessProcess
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BusinessProcess

| Properties | |
| :--- | :--- |
| [Devices](BusinessProcess.Devices.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.BusinessProcesses.BusinessProcess.Devices') | List of devices that will be used when scheduling DeviceWorkloads |
| [Frequency](BusinessProcess.Frequency.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.BusinessProcesses.BusinessProcess.Frequency') | Describes the pattern in time for the Business Process to reoccur. |
| [Holidays](BusinessProcess.Holidays.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.BusinessProcesses.BusinessProcess.Holidays') | Any date listed will result in the WorkLevel for that day being reduced for any DeviceWorkload<br/>that is affected by people. Automated tasks will not be affected. |
| [WorkLevel](BusinessProcess.WorkLevel.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.BusinessProcesses.BusinessProcess.WorkLevel') | The work cycle defined for the business process based on typical work week. Also affected by holidays. |
