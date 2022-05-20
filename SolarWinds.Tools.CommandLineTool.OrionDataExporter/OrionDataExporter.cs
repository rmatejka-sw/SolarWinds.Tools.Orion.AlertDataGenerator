using System.Collections.Generic;

namespace SolarWinds.Tools.CommandLineTool.OrionDataExporter
{
    internal class OrionDataExporter : CommandLineTool
    {
        static void Main(string[] args)
        {
            new OrionDataExporter().Run(args);
        }

        public override IList<ICommandLineAction> Actions => new List<ICommandLineAction>() {new DataExporterAction()};
    }
}
