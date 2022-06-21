#### [SolarWinds.Tools.ModelGenerators](index.md 'index')
### [SolarWinds.Tools.ModelGenerators.Fakes](index.md#SolarWinds.Tools.ModelGenerators.Fakes 'SolarWinds.Tools.ModelGenerators.Fakes')

## OrionFakes Class

```csharp
public class OrionFakes
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; OrionFakes

| Properties | |
| :--- | :--- |
| [MachineType](OrionFakes.MachineType.md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.MachineType') | Returns a random Orion machine type |
| [Vendor](OrionFakes.Vendor.md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.Vendor') | Returns a random Orion Vendor |
| [VendorIcon](OrionFakes.VendorIcon.md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.VendorIcon') | Returns a random Orion Vendor icon image name |
| [VolumeSize](OrionFakes.VolumeSize.md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.VolumeSize') | Returns a random size for a disk volume based on standard sizes currently available. |

| Methods | |
| :--- | :--- |
| [Memory(string, Nullable&lt;DateTime&gt;)](OrionFakes.Memory(string,Nullable_DateTime_).md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.Memory(string, System.Nullable<System.DateTime>)') | Returns CapacityMetricData representing machine memory. Value will be unique if machineId is null.<br/>If machineId is passed, previous value will be returned with updated values for MetricData while<br/>Capacity will remain unchanged. If a pollingInterval is included, new data will be generated on first call<br/>but subsequent calls for the same interval will return the data unchanged. |
| [Status(int, int, int)](OrionFakes.Status(int,int,int).md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.Status(int, int, int)') | Returns a fake Orion status based on the supplied percentages |
| [StatusImage(Nullable&lt;int&gt;)](OrionFakes.StatusImage(Nullable_int_).md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.StatusImage(System.Nullable<int>)') | Orion status image filename based on existing status if fromStatus passed or random by default. |
