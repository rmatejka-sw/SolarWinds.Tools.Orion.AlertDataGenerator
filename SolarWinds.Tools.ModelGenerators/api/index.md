#### [SolarWinds.Tools.ModelGenerators](index.md 'index')

## SolarWinds.Tools.ModelGenerators Assembly
### Namespaces

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator'></a>

## SolarWinds.Tools.ModelGenerators.InternetGenerator Namespace
- **[Device](Device.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.Device')** `Class`
  - **[GenerateObservation(DateTime, TimeRange, WorkWeek)](Device.GenerateObservation(DateTime,TimeRange,WorkWeek).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.Device.GenerateObservation(System.DateTime, SolarWinds.Tools.DataGeneration.Helpers.Models.TimeRange, SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek)')** `Method` Generates faked observations for all device components for the time interval specified
- **[InternetNetworkGenerator](InternetNetworkGenerator.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator')** `Class` Adapted from  
  https://github.com/solarwinds/orion/blob/main/src/libs/tests/SolarWinds.NetPath/SolarWinds.NetPath.Test.Common/TraceRouteGraphGenerator.cs  
  Generates a connected set of network Devices representing a typical Internet topology where a path  
  is connected through one or more Autonomous Systems (AS) which have their own internal structure. Each Device can have  
  one ore more DeviceInterfaces with correctly defined Internet subnet that connects it to  the next network. The  
  connections between networks are tracked as DeviceConnections.
  - **[DeviceConnections](InternetNetworkGenerator.DeviceConnections.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator.DeviceConnections')** `Property` List of DeviceConnections between one DeviceInterface and a second DeviceConnection.
  - **[DeviceInterfaces](InternetNetworkGenerator.DeviceInterfaces.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator.DeviceInterfaces')** `Property` List of all DeviceInterfaces utilized in defining the Internet network as any associated intranets.
  - **[Devices](InternetNetworkGenerator.Devices.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator.Devices')** `Property` List of all Devices comprising the Internet network.
  - **[TotalNetworks](InternetNetworkGenerator.TotalNetworks.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator.TotalNetworks')** `Property` Total number of networks created where each network is defined by multiple paths between a starting  
    and terminating device. All networks are then connected together into a complete Internet.
  - **[CreateNetworks()](InternetNetworkGenerator.CreateNetworks().md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator.CreateNetworks()')** `Method` Uses IInternetGeneratorOptions to generate a complete network of connected devices with accurate subnet definitions and  
    redundant path definitions between start and endpoints.
  - **[PopulateMetrics(TimeRange)](InternetNetworkGenerator.PopulateMetrics(TimeRange).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator.PopulateMetrics(SolarWinds.Tools.DataGeneration.Helpers.Models.TimeRange)')** `Method` TEMPORARY HACK!!!! This will be replaced by BusinessProcess model  
    when I have time to complete which will allow for the creation of more varied  
    and realistic data having dependencies between devices.  
    For now it uses a hard-wire seasons pattern for a fictional business day  
    along with some variability
- **[IDeviceComponent&lt;TMetricData&gt;](IDeviceComponent_TMetricData_.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>')** `Interface` An entity that is part of a device
  - **[ComponentType](IDeviceComponent_TMetricData_.ComponentType.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>.ComponentType')** `Property` Type of component
  - **[Current](IDeviceComponent_TMetricData_.Current.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>.Current')** `Property` Returns the current reading for the MetricData. Equivalent to  
    MetricData.Current
  - **[DeviceIndex](IDeviceComponent_TMetricData_.DeviceIndex.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>.DeviceIndex')** `Property` Global index of device which the component is a part of
  - **[GenerateObservation(DateTime, TimeRange, WorkWeek, double)](IDeviceComponent_TMetricData_.GenerateObservation(DateTime,TimeRange,WorkWeek,double).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>.GenerateObservation(System.DateTime, SolarWinds.Tools.DataGeneration.Helpers.Models.TimeRange, SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek, double)')** `Method` Generates and records observation for the component based on the workWeek workLevel. WorkLevelAffect  
    controls the degree to which the worklevel affects the metric
- **[ComponentType](ComponentType.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.ComponentType')** `Enum`
  - **[Cpu](ComponentType.md#SolarWinds.Tools.ModelGenerators.InternetGenerator.ComponentType.Cpu 'SolarWinds.Tools.ModelGenerators.InternetGenerator.ComponentType.Cpu')** `Field` DeviceCpu type marker
  - **[Device](ComponentType.md#SolarWinds.Tools.ModelGenerators.InternetGenerator.ComponentType.Device 'SolarWinds.Tools.ModelGenerators.InternetGenerator.ComponentType.Device')** `Field` Represents the base component device
  - **[Interface](ComponentType.md#SolarWinds.Tools.ModelGenerators.InternetGenerator.ComponentType.Interface 'SolarWinds.Tools.ModelGenerators.InternetGenerator.ComponentType.Interface')** `Field` DeviceInterface type marker
  - **[Memory](ComponentType.md#SolarWinds.Tools.ModelGenerators.InternetGenerator.ComponentType.Memory 'SolarWinds.Tools.ModelGenerators.InternetGenerator.ComponentType.Memory')** `Field` DeviceMemory type marker
  - **[Volume](ComponentType.md#SolarWinds.Tools.ModelGenerators.InternetGenerator.ComponentType.Volume 'SolarWinds.Tools.ModelGenerators.InternetGenerator.ComponentType.Volume')** `Field` DeviceVolume type marker

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator.BusinessProcesses'></a>

## SolarWinds.Tools.ModelGenerators.InternetGenerator.BusinessProcesses Namespace
- **[BusinessProcess](BusinessProcess.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.BusinessProcesses.BusinessProcess')** `Class` A business process represents a collection of work that happens over time. The work is measured  
  as a WorkLevel ranging from 0 to 100%. The cycle is used to schedule DeviceWorkloads to specific devices  
  over time to represent activity on devices.
  - **[Devices](BusinessProcess.Devices.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.BusinessProcesses.BusinessProcess.Devices')** `Property` List of devices that will be used when scheduling DeviceWorkloads
  - **[Frequency](BusinessProcess.Frequency.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.BusinessProcesses.BusinessProcess.Frequency')** `Property` Describes the pattern in time for the Business Process to reoccur.
  - **[Holidays](BusinessProcess.Holidays.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.BusinessProcesses.BusinessProcess.Holidays')** `Property` Any date listed will result in the WorkLevel for that day being reduced for any DeviceWorkload  
    that is affected by people. Automated tasks will not be affected.
  - **[WorkLevel](BusinessProcess.WorkLevel.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.BusinessProcesses.BusinessProcess.WorkLevel')** `Property` The work cycle defined for the business process based on typical work week. Also affected by holidays.

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents'></a>

## SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents Namespace
- **[DeviceAvailability](DeviceAvailability.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents.DeviceAvailability')** `Class` Represents memory for a device
- **[DeviceCpu](DeviceCpu.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents.DeviceCpu')** `Class` Represents Overall CPU for a device
- **[DeviceLoad](DeviceLoad.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents.DeviceLoad')** `Class` Represents memory for a device
- **[DeviceMemory](DeviceMemory.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents.DeviceMemory')** `Class` Represents memory for a device
- **[DeviceResponseTime](DeviceResponseTime.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents.DeviceResponseTime')** `Class` Represents memory for a device
  - **[MaxResponseTime](DeviceResponseTime.MaxResponseTime.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceComponents.DeviceResponseTime.MaxResponseTime')** `Property` The maximum response time for the device after which the device is considered  
    down.

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads'></a>

## SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads Namespace
- **[ComponentAffect](ComponentAffect.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.ComponentAffect')** `Class` Describes the way a related DeviceWorkload affects the types of components given by ComponentTypes.  
  The Behavior describes how the DeviceWorkload WorkLevel affects changes the component metrics.
  - **[Behavior](ComponentAffect.Behavior.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.ComponentAffect.Behavior')** `Property` Defines how the Device Workload WorkLevel changes the affected components. For example, when set to Linear,  
    changes in the WorkLevel will alter the related component metrics in a linear manner. Other options  
    include Exponential and Logarithmic.
- **[DeviceWorkload](DeviceWorkload.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.DeviceWorkload')** `Class` Represents a specific type of work that is done on a device which can impact the device  
  memory, cpu, interface, and other component metrics. For example, workload for a backup task  
  would affect cpu, memory, interface bandwidth, and volume space. Workload segments  are used to  
  describe the overall shape or envelope for the workload over time. It is very similar to the concept of  
  an Attack, Decay, Sustain, Release envelope used in waveform generation.
  - **[ComponentAffects](DeviceWorkload.ComponentAffects.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.DeviceWorkload.ComponentAffects')** `Property` The components
- **[NonWorkDay](NonWorkDay.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.NonWorkDay')** `Class` Temporary class that returns a WorkLevel based on time of day and day of week.  
  This will be replaced/enhanced by BusinessProcess definitions at a future time
- **[WorkDay](WorkDay.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkDay')** `Class` Temporary class that returns a WorkLevel based on time of day and day of week.  
  This will be replaced/enhanced by BusinessProcess definitions at a future time
- **[WorkloadSegment](WorkloadSegment.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadSegment')** `Class` Defines a single segment of a workload. The duration of the segment  
  is defined in terms of polling intervals.
  - **[WorkloadSegment(int, double)](WorkloadSegment.WorkloadSegment(int,double).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadSegment.WorkloadSegment(int, double)')** `Constructor` Defines a workload segment lasting totalIntervals and changing by  
    percentChangePerInterval each interval.
  - **[WorkloadSegment(int, double, double)](WorkloadSegment.WorkloadSegment(int,double,double).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadSegment.WorkloadSegment(int, double, double)')** `Constructor` Defines a workload segment lasting totalIntervals and from startPercent  
    to endPercent.
  - **[WorkloadSegment(string)](WorkloadSegment.WorkloadSegment(string).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadSegment.WorkloadSegment(string)')** `Constructor` Description of the segment having the following format:  
    TotalIntervals@Rate  
    For example, 5@0.5 describes a segment that is 5 intervals long  
    and increases at a rate of 0.5 percent per interval.  
    Alternately, an absolute ending worklevel can be given using the syntax  
    TotalIntervals>WorkLevel
- **[AffectBehavior](AffectBehavior.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.AffectBehavior')** `Enum` The way a metric is changed by the DeviceWorkload WorkLevel

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator.Options'></a>

## SolarWinds.Tools.ModelGenerators.InternetGenerator.Options Namespace
- **[IInternetGeneratorOptions](IInternetGeneratorOptions.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.Options.IInternetGeneratorOptions')** `Interface` Options for generating a topology typical of the Internet.