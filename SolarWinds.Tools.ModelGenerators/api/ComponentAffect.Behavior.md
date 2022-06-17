#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads](index.md#SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads').[ComponentAffect](ComponentAffect.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.ComponentAffect')

## ComponentAffect.Behavior Property

Defines how the Device Workload WorkLevel changes the affected components. For example, when set to Linear,  
changes in the WorkLevel will alter the related component metrics in a linear manner. Other options  
include Exponential and Logarithmic.

```csharp
public SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.AffectBehavior Behavior { get; set; }
```

#### Property Value
[AffectBehavior](AffectBehavior.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.AffectBehavior')