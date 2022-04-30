# SolarWinds.Tools.CommandLineTool
## Motivation
As author of numerous data-generators, I was tired of copy/pasting the same bits and pieces of code from project-to-project and wasting time to get a basic project up and running where I could focus on the task.

The CommandLineTool was designed as a base-class that includes the following tools for use in any command-line application with the focus on manipulation of Orion data:

- Command Line Options support via [CommandLineParser](https://github.com/commandlineparser/commandline/wiki)
- Predefined options interfaces for [Orion Login](https://github.com/rmatejka-sw/SolarWinds.Tools.Orion.AlertDataGenerator/blob/master/SolarWinds.Tools.CommandLineTool/Options/IOrionOptions.cs), [Orion Database Login](https://github.com/rmatejka-sw/SolarWinds.Tools.Orion.AlertDataGenerator/blob/master/SolarWinds.Tools.CommandLineTool/Options/IDatabaseOptions.cs), and [Time Range Options](https://github.com/rmatejka-sw/SolarWinds.Tools.Orion.AlertDataGenerator/blob/master/SolarWinds.Tools.CommandLineTool/Options/ITimeRangeOptions.cs)
- Simple SQL access using [Dapper.Extensions](https://dapper-tutorial.net/dapper)
- Orion Http Authentication to support WebApi access to any Orion instance
- Proxy classes for accessing the following Orion WebApis: 
  - [SwisApi2](https://github.com/rmatejka-sw/SolarWinds.Tools.Orion.AlertDataGenerator/blob/master/SolarWinds.Tools.CommandLineTool/Service/OrionSWISQueryClient/OrionSWISQueryClient.cs) - SWQL queries against Orion
  - [MapsEntities](https://github.com/rmatejka-sw/SolarWinds.Tools.Orion.AlertDataGenerator/blob/a00f43d5ebb64f6efa34b0e3b42cd9d97c96ff0d/SolarWinds.Tools.CommandLineTool/Service/MapsClient/MapsClient.cs#L3019) - Api for querying entity relations
  - [MapsGraphs](https://github.com/rmatejka-sw/SolarWinds.Tools.Orion.AlertDataGenerator/blob/a00f43d5ebb64f6efa34b0e3b42cd9d97c96ff0d/SolarWinds.Tools.CommandLineTool/Service/MapsClient/MapsClient.cs#L2371) - Api for querying map data for an entity
  - PerfStackEntities - Api for querying entity metrics data
- [SwisEntity](https://github.com/rmatejka-sw/SolarWinds.Tools.Orion.AlertDataGenerator/blob/master/SolarWinds.Tools.CommandLineTool/SwisEntities/SwisEntity.cs) base class that simplies the use of SwisApi2 by mapping results to a generic class:
    ````
        // SELECT * FROM Orion.NetObjectTypes
        IList<NetObjectTypes> netObjectType = SwisEntity.Get<NetObjectTypes>() 
-

## 

