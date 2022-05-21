using System;

namespace SolarWinds.Tools.CommandLineTool.OrionDataExporter
{
    public class AiOpsDataRecord
    {
        public DateTimeOffset TimeStamp { get; set; }
        public double Value { get; set; }
    }
}
