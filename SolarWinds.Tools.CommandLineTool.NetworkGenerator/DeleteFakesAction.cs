using System;
using System.Linq;
using System.Text;
using CommandLine;
using Dapper;
using SolarWinds.Tools.CommandLineTool.Options;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion.Core;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.ModelGenerators.Fakes;
using SolarWinds.Tools.ModelGenerators.Metrics;

namespace SolarWinds.Tools.CommandLineTool.NetworkGenerator
{
    /// <summary>
    /// Deletes any fake data generated from previous runs.
    /// </summary>
    [Verb("DeleteFakes")]
    public class DeleteFakesAction : ICommandLineOptions, ICommandLineAction, IDatabaseOptions
    {
        protected NetworkGenerator NetworkGenerator { get; set; }

        public RunStatus Run(DateTime? timeInterval = null, TimeRange timeRange = null)
        {
            try
            {
                DeleteFakes();
                return RunStatus.Success;
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return RunStatus.CommandError;
        }

        public void AfterRun()
        {
        }

        public void BeforeRun(CommandLineTool commandLineTool)
        {
            this.NetworkGenerator = commandLineTool as NetworkGenerator;
        }

        public string DbServerName { get; set; }
        public string DbName { get; set; }
        public string DbUserName { get; set; }
        public string DbPassword { get; set; }

        public static void DeleteFakes()
        {
            try
            {
                var fakeNodes = DbConnectionManager.DbConnection.Query<Int32>($"SELECT NodeID from NodesData WHERE IOSImage ='{FakerHelper.FakeMarker}'").ToList();
                var relatedTables = new[]
                    {
                        "CPULoad_CS_cur",
                        "CPULoad_CS_Daily_hist",
                        "CPULoad_CS_Detail_hist",
                        "CPULoad_CS_Hourly_hist",
                        "CPUMultiLoad_CS_cur",
                        "CPUMultiLoad_CS_Daily_hist",
                        "CPUMultiLoad_CS_Detail_hist",
                        "CPUMultiLoad_CS_Hourly_hist",
                        "InterfaceAvailability_CS_cur",
                        "InterfaceAvailability_CS_Daily_hist",
                        "InterfaceAvailability_CS_Detail_hist",
                        "InterfaceAvailability_CS_Hourly_hist",
                        "InterfaceErrors_CS_cur",
                        "InterfaceErrors_CS_Daily_hist",
                        "InterfaceErrors_CS_Detail_hist",
                        "InterfaceErrors_CS_Hourly_hist",
                        "InterfaceTraffic_CS_cur",
                        "InterfaceTraffic_CS_Daily_hist",
                        "InterfaceTraffic_CS_Detail_hist",
                        "InterfaceTraffic_CS_Hourly_hist",
                        "InterfaceTrafficUtil_Daily",
                        "LoadAverage_CS_cur",
                        "LoadAverage_CS_Daily_hist",
                        "LoadAverage_CS_Detail_hist",
                        "LoadAverage_CS_Hourly_hist",
                        "ResponseTime_CS_cur",
                        "ResponseTime_CS_Daily_hist",
                        "ResponseTime_CS_Detail_hist",
                        "ResponseTime_CS_Hourly_hist",
                        "VolumeUsage_CS_cur",
                        "VolumeUsage_CS_Daily_hist",
                        "VolumeUsage_CS_Detail_hist",
                        "VolumeUsage_CS_Hourly_hist",
                        "NodesStatistics",
                        "NodesCustomProperties"
                    };
                var command = new StringBuilder();
                foreach (var nodeID in fakeNodes)
                {
                    foreach (var table in relatedTables)
                    {
                        command.AppendLine($"DELETE dbo.{table} where NodeID={nodeID};");
                    }
                    command.AppendLine($"DELETE dbo.TopologyConnections where SourceNodeID={nodeID} or MappedNodeID={nodeID};");
                    DbConnectionManager.DbConnection.Execute(command.ToString());
                    command.Clear();
                }
                command.AppendLine($"DELETE dbo.AIIM_AnomalyHistory;");
                command.AppendLine($"DELETE dbo.AIIM_AiOpsMetricStatus;");
                command.AppendLine($"DELETE dbo.NodesData where IOSImage='{FakerHelper.FakeMarker}';");
                command.AppendLine($"DELETE dbo.ShadowNodes where NodeName like'%{FakerHelper.FakeName}%';");
                command.AppendLine($"DELETE dbo.Interfaces where Comments='{FakerHelper.FakeMarker})';");
                command.AppendLine($"DELETE dbo.Events where EventType={Events.AnomalyDetectedTypeId};");
                command.AppendLine($"DELETE dbo.Events where EventType={Events.AnomalyDetectedTypeId};");
                command.AppendLine($"DELETE dbo.Volumes where DiskSerialNumber like'%{FakerHelper.FakeName}%';");
                DbConnectionManager.DbConnection.Execute(command.ToString());
            }
            catch (Exception ex)
            {
                ConsoleLogger.Error($"DeleteFakes failed: {ex.Message}");
            }
        }
    }
}
