using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using CommandLine;
using SolarWinds.Tools.CommandLineTool.Options;
using SolarWinds.Tools.CommandLineTool.OrionDataExporter.Extensions;
using SolarWinds.Tools.CommandLineTool.Service;
using SolarWinds.Tools.DataGeneration.Helpers;
using SolarWinds.Tools.DataGeneration.Services;

namespace SolarWinds.Tools.CommandLineTool.OrionDataExporter
{
    [Verb("Export")]
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

        public RunStatus Run(DateTime? timeInterval = null)
        {
            try
            {
                //var nodes = SwisEntity.GetManagedEntityByType("Orion.Nodes");
                var nodes = WebApiManager.PerfStackEntities.GetManagedEntitiesAsync("Orion.Nodes", 1).Result.Data;
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
                var pollingInterval = TimeSpan.FromMinutes(10);
                foreach (var metricId in Metrics)
                {
                    foreach (var node in nodes)
                    {
                        var entityMetricId = $"{node.Id}-{metricId}";
                        var resolution = (int)TimeSpan.FromMinutes(10).TotalSeconds;
                        var startTime = now.Subtract(TimeSpan.FromDays(this.PastDays));
                        var endTime = startTime.Add(TimeSpan.FromDays(1));
                        this.CreateArchiveEntry(entityMetricId);
                        for (int daysIndex = 0; daysIndex < this.PastDays; daysIndex++)
                        {
                            //http://rmatejka-dvb.swdev.local/api2/perfstack/metrics/0_Orion.Nodes_1-Orion.CPULoad.AvgLoad/?endTime=2022-05-18T10:27:19.717Z&resolution=7380&startTime=2022-04-27T22:27:00.000Z
                            var result = WebApiManager.PerfStackMetrics.GetMeasurementForEntityV1Async(
                                entityMetricId,
                                0,
                                startTime.ToUniversalTime().ToString("o"),
                                endTime.ToUniversalTime().ToString("o"),
                                resolution).Result;
                        var measurements = result.Measurements ?? this.CreateNullMeasurements(startTime, endTime, pollingInterval);
                            this.currentArchiveEntryStreamWriter.WriteMeasurements(measurements, pollingInterval);
                            startTime = endTime;
                            endTime = startTime.Add(TimeSpan.FromDays(1));
                        }

                    }
                }
                this.currentArchiveEntryStreamWriter.Close();
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return RunStatus.CommandError;
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

        private void CreateArchiveEntry(string entityMetricId)
        {
            try
            {
                if (this.currentArchiveEntryStreamWriter != null)
                {
                    ConsoleLogger.Success($"FINISHED WRITING");
                    this.currentArchiveEntryStreamWriter?.Close();
                }
                var archiveEntryPath = $"{this.archiveRoot}/{Guid.NewGuid()}/{entityMetricId.Replace(".","_")}.csv";
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
                this.FilePath = $"{this.OrionServerName}_{now:yyyyMMDDhhmmss}.zip";
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
