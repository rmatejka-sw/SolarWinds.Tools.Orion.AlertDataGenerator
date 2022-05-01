#### [SolarWinds.Tools.CommandLineTool](index.md 'index')

## SolarWinds.Tools.CommandLineTool Assembly
### Namespaces

<a name='SolarWinds.Tools.CommandLineTool'></a>

## SolarWinds.Tools.CommandLineTool Namespace
- **[CommandLineTool&lt;TOptions&gt;](CommandLineTool_TOptions_.md 'SolarWinds.Tools.CommandLineTool.CommandLineTool<TOptions>')** `Class` Provides common support for command-line application with focus on data-generation for Orion.  
  Includes support for parsing command line options, Orion Authentication for WebApi access, and Orion  
  SQL server access.
  - **[GenerateIntervalData(DateTime)](CommandLineTool_TOptions_.GenerateIntervalData(DateTime).md 'SolarWinds.Tools.CommandLineTool.CommandLineTool<TOptions>.GenerateIntervalData(System.DateTime)')** `Method` Called once per every interval as defined in ITimeRangeOptions. For example, -pastdays 5 and  
    -PollingInterval 10 minutes would result in 5*24*60/10= 720 calls to this method with the time  
    going from Now to 5 days in the past. Client should override to provide their implementation.
  - **[Run()](CommandLineTool_TOptions_.Run().md 'SolarWinds.Tools.CommandLineTool.CommandLineTool<TOptions>.Run()')** `Method` Validates command line options, connects to SQl Server, and then begins calling GenerateIntervalData  
    for the total number of times determined from the ITimeRangeOptions.

<a name='SolarWinds.Tools.CommandLineTool.Service'></a>

## SolarWinds.Tools.CommandLineTool.Service Namespace
- **[OrionAuthenticator](OrionAuthenticator.md 'SolarWinds.Tools.CommandLineTool.Service.OrionAuthenticator')** `Class` Class that will do authentication against Orion.

<a name='SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient'></a>

## SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient Namespace
- **[SwisClient](SwisClient.md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient')** `Class`
  - **[CreateAndReadAsync(CrudData)](SwisClient.CreateAndReadAsync(CrudData).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.CreateAndReadAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.CrudData)')** `Method`
  - **[CreateAndReadAsync(CrudData, CancellationToken)](SwisClient.CreateAndReadAsync(CrudData,CancellationToken).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.CreateAndReadAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.CrudData, System.Threading.CancellationToken)')** `Method`
  - **[CreateAsync(CrudData)](SwisClient.CreateAsync(CrudData).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.CreateAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.CrudData)')** `Method`
  - **[CreateAsync(CrudData, CancellationToken)](SwisClient.CreateAsync(CrudData,CancellationToken).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.CreateAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.CrudData, System.Threading.CancellationToken)')** `Method`
  - **[DeleteAsync(CrudData)](SwisClient.DeleteAsync(CrudData).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.DeleteAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.CrudData)')** `Method`
  - **[DeleteAsync(CrudData, CancellationToken)](SwisClient.DeleteAsync(CrudData,CancellationToken).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.DeleteAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.CrudData, System.Threading.CancellationToken)')** `Method`
  - **[Invoke2Async(InvokeParam)](SwisClient.Invoke2Async(InvokeParam).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.Invoke2Async(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.InvokeParam)')** `Method`
  - **[Invoke2Async(InvokeParam, CancellationToken)](SwisClient.Invoke2Async(InvokeParam,CancellationToken).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.Invoke2Async(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.InvokeParam, System.Threading.CancellationToken)')** `Method`
  - **[InvokeAsync(InvokeParam)](SwisClient.InvokeAsync(InvokeParam).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.InvokeAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.InvokeParam)')** `Method`
  - **[InvokeAsync(InvokeParam, CancellationToken)](SwisClient.InvokeAsync(InvokeParam,CancellationToken).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.InvokeAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.InvokeParam, System.Threading.CancellationToken)')** `Method`
  - **[InvokeToString2Async(InvokeParam)](SwisClient.InvokeToString2Async(InvokeParam).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.InvokeToString2Async(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.InvokeParam)')** `Method`
  - **[InvokeToString2Async(InvokeParam, CancellationToken)](SwisClient.InvokeToString2Async(InvokeParam,CancellationToken).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.InvokeToString2Async(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.InvokeParam, System.Threading.CancellationToken)')** `Method`
  - **[InvokeToStringAsync(InvokeParam)](SwisClient.InvokeToStringAsync(InvokeParam).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.InvokeToStringAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.InvokeParam)')** `Method`
  - **[InvokeToStringAsync(InvokeParam, CancellationToken)](SwisClient.InvokeToStringAsync(InvokeParam,CancellationToken).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.InvokeToStringAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.InvokeParam, System.Threading.CancellationToken)')** `Method`
  - **[Query2Async(QueryParam)](SwisClient.Query2Async(QueryParam).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.Query2Async(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.QueryParam)')** `Method`
  - **[Query2Async(QueryParam, CancellationToken)](SwisClient.Query2Async(QueryParam,CancellationToken).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.Query2Async(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.QueryParam, System.Threading.CancellationToken)')** `Method`
  - **[QueryAsync(QueryParam)](SwisClient.QueryAsync(QueryParam).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.QueryAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.QueryParam)')** `Method`
  - **[QueryAsync(QueryParam, CancellationToken)](SwisClient.QueryAsync(QueryParam,CancellationToken).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.QueryAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.QueryParam, System.Threading.CancellationToken)')** `Method`
  - **[Read2Async(string)](SwisClient.Read2Async(string).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.Read2Async(string)')** `Method`
  - **[Read2Async(string, CancellationToken)](SwisClient.Read2Async(string,CancellationToken).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.Read2Async(string, System.Threading.CancellationToken)')** `Method`
  - **[ReadAsync(string)](SwisClient.ReadAsync(string).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.ReadAsync(string)')** `Method`
  - **[ReadAsync(string, CancellationToken)](SwisClient.ReadAsync(string,CancellationToken).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.ReadAsync(string, System.Threading.CancellationToken)')** `Method`
  - **[UpdateAsync(CrudData)](SwisClient.UpdateAsync(CrudData).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.UpdateAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.CrudData)')** `Method`
  - **[UpdateAsync(CrudData, CancellationToken)](SwisClient.UpdateAsync(CrudData,CancellationToken).md 'SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.SwisClient.UpdateAsync(SolarWinds.Tools.CommandLineTool.Service.OrionSWISQueryClient.CrudData, System.Threading.CancellationToken)')** `Method`