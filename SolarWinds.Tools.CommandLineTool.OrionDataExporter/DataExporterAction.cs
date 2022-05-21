using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using CommandLine;
using SolarWinds.Tools.CommandLineTool.Options;
using SolarWinds.Tools.CommandLineTool.Service;
using SolarWinds.Tools.DataGeneration.DAL.SwisEntities;
using SolarWinds.Tools.DataGeneration.DAL.Tables.Orion;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.DataGeneration.Services;

namespace SolarWinds.Tools.CommandLineTool.OrionDataExporter
{
    [Verb("export")]
    public class DataExporterAction : ICommandLineAction,
    IOrionOptions
    {

        private ZipArchive exportArchive;
        private ZipArchiveEntry currentArchiveEntry;
        private StreamWriter currentArchiveEntryStreamWriter;
        private string archiveRoot;

        [Option("FilePath", HelpText = "Path to export archive. Default is the same directory as the exe with filename based on OrionServer and data range.")]
        public string FilePath { get; set; }

        [Option(Default = "oriondemo.solarwinds.com")]
        public string OrionServerName { get; set; }

        [Option(Default = true)]
        public bool UseHttps { get; set; }

        [Option(Default = "guest")]
        public string OrionUserName { get; set; }

        [Option(Default = "orion")]
        public string OrionPassword { get; set; }

        [Option("PastDays", Default = 21, HelpText = "Number of days of historic data to export.")]
        public int PastDays { get; set; }

        [Option('m', "Metrics", Separator = '|')]
        public IEnumerable<string> Metrics { get; set; }

        [Option("MaxNodes", Default = 3, HelpText = "Total number of nodes from which metrics will be exported.")]
        public int MaxNodes { get; set; }

        public RunStatus Run(DateTime? timeInterval = null)
        {
            try
            {
                var nodes = WebApiManager.PerfStackEntities.GetManagedEntitiesAsync("Orion.Nodes", 200).Result.Data;
                var alertObjectsQuery = @"SELECT DISTINCT ao.EntityNetObjectId
FROM Orion.AlertHistory ah
JOIN Orion.AlertObjects ao on ao.AlertObjectID=ah.AlertObjectId
WHERE ao.EntityType = 'Orion.Nodes'
ORDER BY ao.TriggeredCount DESC";
                var alertObjects = SwisEntity.Get<AlertObjects>(alertObjectsQuery);

                if (!Metrics.Any())
                {
                    Metrics = new List<string>()
                    {
                        "Orion.CPULoad.AvgLoad",
                        "Orion.ResponseTime.AvgResponseTime"
                    };
                }
                this.archiveRoot = this.OrionServerName.Replace(".", "_");
                var now = DateTime.UtcNow;
                foreach (var metricId in Metrics)
                {
                    var exportedEntities = 0;
                    foreach (var alertObject in alertObjects)
                    {
                        var opid = NetObjectTypes.NetObjectIdToOpid(alertObject.EntityNetObjectId);
                        if (opid == null) continue;
                        var entityMetricId = $"{opid}-{metricId}";
                        var records = LoadMeasurements(entityMetricId, now);
                        if (records == null)
                        {
                            ConsoleLogger.Warning($"Skipped {entityMetricId}: no measurements found for date range.");
                            continue;
                        }
                        if (records.Max(r => r.Value) - records.Min(r => r.Value) <= 1)
                        {
                            ConsoleLogger.Warning($"Skipped {entityMetricId}: Minimal changes in data.");
                            continue;
                        }
                        if (records.Count(r => r.Value == 0) >= records.Count/2)
                        {
                            ConsoleLogger.Warning($"Skipped {entityMetricId}: Over 50% of the records are zero.");
                            continue;
                        }
                        this.CreateArchiveEntry(opid.ToString(), metricId, $"{entityMetricId}");
                        foreach (var record in records)
                        {
                            this.currentArchiveEntryStreamWriter.WriteLine($"{record.TimeStamp},{record.Value}");
                        }

                        exportedEntities += 1;
                        if (exportedEntities >= this.MaxNodes) break;
                    }
                }
                this.currentArchiveEntryStreamWriter?.Close();
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return RunStatus.CommandError;
        }

        private IList<AiOpsDataRecord> LoadMeasurements(string entityMetricId, DateTime now)
        {
            var records = new List<AiOpsDataRecord>();
            var resolution = (int)TimeSpan.FromMinutes(10).TotalSeconds;
            var startTime = now.Subtract(TimeSpan.FromDays(this.PastDays));
            var endTime = startTime.Add(TimeSpan.FromDays(1));
            var pollingInterval = TimeSpan.FromMinutes(10);
            for (int daysIndex = 0; daysIndex < this.PastDays; daysIndex++)
            {
                //http://rmatejka-dvb.swdev.local/api2/perfstack/metrics/0_Orion.Nodes_1-Orion.CPULoad.AvgLoad/?endTime=2022-05-18T10:27:19.717Z&resolution=7380&startTime=2022-04-27T22:27:00.000Z
                var result = WebApiManager.PerfStackMetrics.GetMeasurementForEntityV1Async(
                    entityMetricId,
                    0,
                    startTime.ToUniversalTime().ToString("o"),
                    endTime.ToUniversalTime().ToString("o"),
                    resolution).Result;
                if (result?.Measurements == null && daysIndex == 0)
                {
                    return null;
                };
                var measurements = result.Measurements ?? this.CreateNullMeasurements(startTime, endTime, pollingInterval);
                var totalMeasurements = measurements.Count;
                Measurement previous = null;
                foreach (var measurement in measurements)
                {
                    if (previous != null || totalMeasurements == 1)
                    {
                        FillMissingIntervals(totalMeasurements, measurement, previous, pollingInterval, records);
                    }
                    records.Add(new AiOpsDataRecord { TimeStamp = measurement.DateTimeStamp, Value = measurement.Value });
                    previous = measurement;
                }
                startTime = endTime;
                endTime = startTime.Add(TimeSpan.FromDays(1));
            }
            return records;
        }

        private static void FillMissingIntervals(int totalMeasurements, Measurement measurement, Measurement previous,
            TimeSpan pollingInterval, List<AiOpsDataRecord> records)
        {
            var delta = totalMeasurements == 1
                ? TimeSpan.FromDays(1)
                : measurement.DateTimeStamp.Subtract(previous.DateTimeStamp);
            previous ??= measurement;
            var fillCount = Math.Round((float)delta.TotalMinutes / (float)pollingInterval.TotalMinutes) - 1.0;
            while (fillCount-- > 0)
            {
                previous.DateTimeStamp = previous.DateTimeStamp.Add(pollingInterval);
                records.Add(new AiOpsDataRecord { TimeStamp = previous.DateTimeStamp, Value = previous.Value });
            }
        }

        private Measurements CreateNullMeasurements(DateTime startTime, DateTime endTime, TimeSpan pollingInterval)
        {
            var measurements = new Measurements();
            var currentTime = new DateTime(startTime.Ticks);
            while (currentTime < endTime)
            {
                measurements.Add(new Measurement
                {
                    Value = 0.0,
                    DateTimeStamp = new DateTime(currentTime.Ticks),
                });
                currentTime = currentTime.Add(pollingInterval);
            }
            return measurements;
        }

        private void CreateArchiveEntry(string entityOpid, string metricId, string entityMetricId)
        {
            try
            {
                if (this.currentArchiveEntryStreamWriter != null)
                {
                    ConsoleLogger.Success($"FINISHED WRITING");
                    this.currentArchiveEntryStreamWriter?.Close();
                }
                var archiveEntryPath = $"{this.archiveRoot}/{metricId}/{entityMetricId.Replace(".", "_")}.csv";
                ConsoleLogger.Info($"Writing {archiveEntryPath}....");
                this.currentArchiveEntry = this.exportArchive.CreateEntry(archiveEntryPath);
                this.currentArchiveEntryStreamWriter = new StreamWriter(this.currentArchiveEntry.Open(), Encoding.Default);
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }
        }

        public void AfterRun()
        {

            exportArchive?.Dispose();
        }

        public void BeforeRun(CommandLineTool commandLineTool)
        {
            if (String.IsNullOrEmpty(this.FilePath))
            {
                var now = DateTime.Now;
                this.FilePath = $"{this.OrionServerName}_{now:yyyyMMddhhmmss}.zip";
            }
            this.exportArchive = ZipFile.Open(this.FilePath, ZipArchiveMode.Create);
        }

        private void GenerateStaticData()
        {
            try
            {

            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }
        }
    }
}
