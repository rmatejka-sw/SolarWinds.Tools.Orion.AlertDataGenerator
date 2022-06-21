#### [SolarWinds.Tools.ModelGenerators](index.md 'index')

## SolarWinds.Tools.ModelGenerators Assembly
### Namespaces

<a name='SolarWinds.Tools.ModelGenerators.Extensions'></a>

## SolarWinds.Tools.ModelGenerators.Extensions Namespace
- **[DateTimeExtensions](DateTimeExtensions.md 'SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions')** `Class`
  - **[ToPollingInterval(this DateTime, TimeSpan, RoundDirection)](DateTimeExtensions.ToPollingInterval(thisDateTime,TimeSpan,RoundDirection).md 'SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.ToPollingInterval(this System.DateTime, System.TimeSpan, SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.RoundDirection)')** `Method` Returns new DateTime that has been normalized to a time aligned with the start of the hour.  
    For example, if passed 1/1/2020 1:15am, for a 10 minutes polling interval, returns 1/1/2020 1:20am.
  - **[ToTimeInterval(this DateTime, TimeSpan)](DateTimeExtensions.ToTimeInterval(thisDateTime,TimeSpan).md 'SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.ToTimeInterval(this System.DateTime, System.TimeSpan)')** `Method` Takes a DateTime and rounds to the interval start time if the time  
    is less than the normalized start time (e.g., 5, 10, 15 for 5 minute  
    interval span)
  - **[ToTimeIntervalIndex(this DateTime, TimeRange, int)](DateTimeExtensions.ToTimeIntervalIndex(thisDateTime,TimeRange,int).md 'SolarWinds.Tools.ModelGenerators.Extensions.DateTimeExtensions.ToTimeIntervalIndex(this System.DateTime, SolarWinds.Tools.ModelGenerators.Metrics.TimeRange, int)')** `Method` Returns the zero-based interval index date dateTime falls into  
    for the specified TimeRange. If TimeRange is null, uses a default TimeRange  
    of 24 hours with the first interval starting at midnight.

<a name='SolarWinds.Tools.ModelGenerators.Fakes'></a>

## SolarWinds.Tools.ModelGenerators.Fakes Namespace
- **[OrionFakes](OrionFakes.md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes')** `Class`
  - **[MachineType](OrionFakes.MachineType.md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.MachineType')** `Property` Returns a random Orion machine type
  - **[Vendor](OrionFakes.Vendor.md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.Vendor')** `Property` Returns a random Orion Vendor
  - **[VendorIcon](OrionFakes.VendorIcon.md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.VendorIcon')** `Property` Returns a random Orion Vendor icon image name
  - **[VolumeSize](OrionFakes.VolumeSize.md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.VolumeSize')** `Property` Returns a random size for a disk volume based on standard sizes currently available.
  - **[Memory(string, Nullable&lt;DateTime&gt;)](OrionFakes.Memory(string,Nullable_DateTime_).md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.Memory(string, System.Nullable<System.DateTime>)')** `Method` Returns CapacityMetricData representing machine memory. Value will be unique if machineId is null.  
    If machineId is passed, previous value will be returned with updated values for MetricData while  
    Capacity will remain unchanged. If a pollingInterval is included, new data will be generated on first call  
    but subsequent calls for the same interval will return the data unchanged.
  - **[Status(int, int, int)](OrionFakes.Status(int,int,int).md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.Status(int, int, int)')** `Method` Returns a fake Orion status based on the supplied percentages
  - **[StatusImage(Nullable&lt;int&gt;)](OrionFakes.StatusImage(Nullable_int_).md 'SolarWinds.Tools.ModelGenerators.Fakes.OrionFakes.StatusImage(System.Nullable<int>)')** `Method` Orion status image filename based on existing status if fromStatus passed or random by default.

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator'></a>

## SolarWinds.Tools.ModelGenerators.InternetGenerator Namespace
- **[Device](Device.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.Device')** `Class`
  - **[GenerateObservation(DateTime, TimeRange, WorkWeek)](Device.GenerateObservation(DateTime,TimeRange,WorkWeek).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.Device.GenerateObservation(System.DateTime, SolarWinds.Tools.ModelGenerators.Metrics.TimeRange, SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek)')** `Method` Generates faked observations for all device components for the time interval specified
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
  - **[PopulateMetrics(TimeRange)](InternetNetworkGenerator.PopulateMetrics(TimeRange).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.InternetNetworkGenerator.PopulateMetrics(SolarWinds.Tools.ModelGenerators.Metrics.TimeRange)')** `Method` TEMPORARY HACK!!!! This will be replaced by BusinessProcess model  
    when I have time to complete which will allow for the creation of more varied  
    and realistic data having dependencies between devices.  
    For now it uses a hard-wire seasons pattern for a fictional business day  
    along with some variability
- **[IDeviceComponent&lt;TMetricData&gt;](IDeviceComponent_TMetricData_.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>')** `Interface` An entity that is part of a device
  - **[ComponentType](IDeviceComponent_TMetricData_.ComponentType.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>.ComponentType')** `Property` Type of component
  - **[Current](IDeviceComponent_TMetricData_.Current.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>.Current')** `Property` Returns the current reading for the MetricData. Equivalent to  
    MetricData.Current
  - **[DeviceIndex](IDeviceComponent_TMetricData_.DeviceIndex.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>.DeviceIndex')** `Property` Global index of device which the component is a part of
  - **[GenerateObservation(DateTime, TimeRange, WorkWeek, double)](IDeviceComponent_TMetricData_.GenerateObservation(DateTime,TimeRange,WorkWeek,double).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.IDeviceComponent<TMetricData>.GenerateObservation(System.DateTime, SolarWinds.Tools.ModelGenerators.Metrics.TimeRange, SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek, double)')** `Method` Generates and records observation for the component based on the workWeek workLevel. WorkLevelAffect  
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
  - **[GetWorkLevelForInterval(DateTime, TimeSpan)](WorkDay.GetWorkLevelForInterval(DateTime,TimeSpan).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkDay.GetWorkLevelForInterval(System.DateTime, System.TimeSpan)')** `Method` Return WorkLevel as a percentage between 0 and 100
- **[WorkloadDefinition](WorkloadDefinition.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadDefinition')** `Class`
  - **[WorkloadDefinition(string[])](WorkloadDefinition.WorkloadDefinition(string[]).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadDefinition.WorkloadDefinition(string[])')** `Constructor` Defines the workload response using multiple segments  
    having the following format:  
    TotalIntervals@Rate  
    For example, 5@0.5 describes a segment that is 5 intervals long  
    and increases at a rate of 0.5 percent per interval.  
    Alternately, an absolute ending worklevel can be given using the syntax  
    TotalIntervals>WorkLevel
  - **[WorkloadLevels(double, Nullable&lt;int&gt;, int)](WorkloadDefinition.WorkloadLevels(double,Nullable_int_,int).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadDefinition.WorkloadLevels(double, System.Nullable<int>, int)')** `Method` Returns WorkLevel between 0 and 100
  - **[WorkloadRates(double)](WorkloadDefinition.WorkloadRates(double).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadDefinition.WorkloadRates(double)')** `Method` Enumerable for WorkloadRates returning value between 0 and 100 representing workload rate of change for the interval
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
  - **[WorkloadLevels(double, Nullable&lt;int&gt;, int)](WorkloadSegment.WorkloadLevels(double,Nullable_int_,int).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadSegment.WorkloadLevels(double, System.Nullable<int>, int)')** `Method` Enumerable for WorkLevels returning value between 0 and 100 representing workload percentage
  - **[WorkloadRates(double)](WorkloadSegment.WorkloadRates(double).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkloadSegment.WorkloadRates(double)')** `Method` Enumerable for WorkloadRates returning value between 0 and 100 representing workload rate of change for the interval
- **[WorkWeek](WorkWeek.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek')** `Class`
  - **[GetWorkLevelForInterval(DateTime, TimeSpan)](WorkWeek.GetWorkLevelForInterval(DateTime,TimeSpan).md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.WorkWeek.GetWorkLevelForInterval(System.DateTime, System.TimeSpan)')** `Method` Returns WorkLevel as percentage between 0 and 100
- **[AffectBehavior](AffectBehavior.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.DeviceWorkloads.AffectBehavior')** `Enum` The way a metric is changed by the DeviceWorkload WorkLevel

<a name='SolarWinds.Tools.ModelGenerators.InternetGenerator.Options'></a>

## SolarWinds.Tools.ModelGenerators.InternetGenerator.Options Namespace
- **[IInternetGeneratorOptions](IInternetGeneratorOptions.md 'SolarWinds.Tools.ModelGenerators.InternetGenerator.Options.IInternetGeneratorOptions')** `Interface` Options for generating a topology typical of the Internet.

<a name='SolarWinds.Tools.ModelGenerators.Metrics'></a>

## SolarWinds.Tools.ModelGenerators.Metrics Namespace
- **[AnomalyGenerator](AnomalyGenerator.md 'SolarWinds.Tools.ModelGenerators.Metrics.AnomalyGenerator')** `Class`
  - **[NextValue(bool)](AnomalyGenerator.NextValue(bool).md 'SolarWinds.Tools.ModelGenerators.Metrics.AnomalyGenerator.NextValue(bool)')** `Method` Returns next anomalous value in a sequence. If sequence has completed and  
    start is false, null is returned. Once the sequence has been started, start  
    is ignored.
- **[CapacityMetricData](CapacityMetricData.md 'SolarWinds.Tools.ModelGenerators.Metrics.CapacityMetricData')** `Class` Represents Metric Data that has a physical capacity like memory, disk space,  
  and bandwidth. Base MetricData will be bounded by the Capacity.
  - **[PhysicalCapacities](CapacityMetricData.PhysicalCapacities.md 'SolarWinds.Tools.ModelGenerators.Metrics.CapacityMetricData.PhysicalCapacities')** `Property` List of typical capacities for the associated physical device. For example,  
    disk drives could be 500MB, 1TB, 2TB, etc.
- **[MetricData](MetricData.md 'SolarWinds.Tools.ModelGenerators.Metrics.MetricData')** `Class` Used to represent faked metric data for a single point in time. All values will be consistent  
  (Current and average will never be greater or less than max and min respectively).
- **[TimeRange](TimeRange.md 'SolarWinds.Tools.ModelGenerators.Metrics.TimeRange')** `Class`
  - **[PollingIntervals()](TimeRange.PollingIntervals().md 'SolarWinds.Tools.ModelGenerators.Metrics.TimeRange.PollingIntervals()')** `Method` Iterates over TimeRange from StartDate to EndDate every PollingInterval
- **[VolumeTypeInfo](VolumeTypeInfo.md 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeTypeInfo')** `Class`
  - **[Caption](VolumeTypeInfo.Caption.md 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeTypeInfo.Caption')** `Property` Returns a Volume name based on VolumeType.
  - **[DeviceId](VolumeTypeInfo.DeviceId.md 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeTypeInfo.DeviceId')** `Property` Returns device id based on Type.
  - **[IsPhysicalDisk](VolumeTypeInfo.IsPhysicalDisk.md 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeTypeInfo.IsPhysicalDisk')** `Property` Returns true if the VolumeType represents a physical disk
  - **[Label](VolumeTypeInfo.Label.md 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeTypeInfo.Label')** `Property` Returns random Label based on VolumeType
  - **[SerialNumber](VolumeTypeInfo.SerialNumber.md 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeTypeInfo.SerialNumber')** `Property` Returns random SerialNumber based on VolumeType
  - **[TypeIcon](VolumeTypeInfo.TypeIcon.md 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeTypeInfo.TypeIcon')** `Property` Image for VolumeType
  - **[TypeId](VolumeTypeInfo.TypeId.md 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeTypeInfo.TypeId')** `Property` Volume type id for Type
  - **[TypeName](VolumeTypeInfo.TypeName.md 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeTypeInfo.TypeName')** `Property` Returns type name for Type
  - **[VolumeType](VolumeTypeInfo.VolumeType.md 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeTypeInfo.VolumeType')** `Property` Randomly generate VolumeType
- **[IMetricData](IMetricData.md 'SolarWinds.Tools.ModelGenerators.Metrics.IMetricData')** `Interface`
  - **[RestoreTo(DateTime, TimeRange)](IMetricData.RestoreTo(DateTime,TimeRange).md 'SolarWinds.Tools.ModelGenerators.Metrics.IMetricData.RestoreTo(System.DateTime, SolarWinds.Tools.ModelGenerators.Metrics.TimeRange)')** `Method` Restores historic Metric date from the requested polling interval.  
    NOTE: Current value is set to historic value. Call RestoreToLatest
  - **[RestoreToLatest()](IMetricData.RestoreToLatest().md 'SolarWinds.Tools.ModelGenerators.Metrics.IMetricData.RestoreToLatest()')** `Method` Restores current value to the value prior to calling  
    RestoreTo and returns the current value. If Restore was not called,  
    returns the current value.
- **[VolumeType](VolumeType.md 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeType')** `Enum`
  - **[CompactDisk](VolumeType.md#SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.CompactDisk 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.CompactDisk')** `Field` Compact disk
  - **[FixedDisk](VolumeType.md#SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.FixedDisk 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.FixedDisk')** `Field` Fixed disk
  - **[FlashMemory](VolumeType.md#SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.FlashMemory 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.FlashMemory')** `Field` Flash memory
  - **[FloppyDisk](VolumeType.md#SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.FloppyDisk 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.FloppyDisk')** `Field` Floppy disk
  - **[MountPoint](VolumeType.md#SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.MountPoint 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.MountPoint')** `Field` Mount point
  - **[NetworkDisk](VolumeType.md#SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.NetworkDisk 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.NetworkDisk')** `Field` Network disk
  - **[Other](VolumeType.md#SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.Other 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.Other')** `Field` Know volume type but not one of listed here
  - **[RAM](VolumeType.md#SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.RAM 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.RAM')** `Field` RAM
  - **[RAMDisk](VolumeType.md#SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.RAMDisk 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.RAMDisk')** `Field` RAM disk
  - **[RemovableDisk](VolumeType.md#SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.RemovableDisk 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.RemovableDisk')** `Field` Removable disk
  - **[Unknown](VolumeType.md#SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.Unknown 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.Unknown')** `Field` Unknown volume type
  - **[VirtualMemory](VolumeType.md#SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.VirtualMemory 'SolarWinds.Tools.ModelGenerators.Metrics.VolumeType.VirtualMemory')** `Field` Virtual memory