using System;
using System.IO;
using System.Net;
using SolarWinds.Tools.CommandLineTool.Service;
using SolarWinds.Tools.DataGeneration.Helpers;

namespace SolarWinds.Tools.CommandLineTool.OrionDataExporter.Extensions
{
    public static class StreamWriterExtensions
    {
        public static int WriteMeasurements(this StreamWriter zipArchiveEntryStreamWriter, Measurements measurements, TimeSpan pollTime)
        {
            try
            {
                Measurement previous = null;
                foreach (var measurement in measurements)
                {
                    if (previous != null)
                    {
                        var delta = measurement.DateTimeStamp.Subtract(previous.DateTimeStamp);
                        var fillCount = Math.Round((float)delta.Minutes/ (float)pollTime.Minutes) - 1.0;
                        while (fillCount-- > 0)
                        {
                            previous.DateTimeStamp = previous.DateTimeStamp.Add(pollTime);
                            WriteMeasurement(zipArchiveEntryStreamWriter, previous);
                        }
                    }
                    WriteMeasurement(zipArchiveEntryStreamWriter, measurement);
                    previous = measurement;
                }
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return 0;
        }

        private static void WriteMeasurement( StreamWriter zipArchiveEntryStreamWriter, Measurement measurement) => zipArchiveEntryStreamWriter.WriteLine($"{measurement.DateTimeStamp},{measurement.Value}");
    }
}
