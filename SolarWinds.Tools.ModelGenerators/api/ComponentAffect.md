#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads](index.md#SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads')

## ComponentAffect Class

Describes the way a related DeviceWorkload affects the types of components given by ComponentTypes.  
The Behavior describes how the DeviceWorkload WorkLevel affects changes the component metrics.

```csharp
public class ComponentAffect
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ComponentAffect

| Properties | |
| :--- | :--- |
| [Behavior](ComponentAffect.Behavior.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.ComponentAffect.Behavior') | Defines how the Device Workload WorkLevel changes the affected components. For example, when set to Linear,<br/>changes in the WorkLevel will alter the related component metrics in a linear manner. Other options<br/>include Exponential and Logarithmic. |
