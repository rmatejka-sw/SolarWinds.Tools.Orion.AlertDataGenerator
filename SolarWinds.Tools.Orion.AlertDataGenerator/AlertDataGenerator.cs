using System;
using SolarWinds.Tools.CommandLineTool;
using SolarWinds.Tools.CommandLineTool.Helpers;
using SolarWinds.Tools.CommandLineTool.Service;
using SolarWinds.Tools.Orion.AlertDataGenerator.Models;


namespace SolarWinds.Tools.Orion.AlertDataGenerator
{
    public class AlertDataGenerator : CommandLineTool<AlertDataGeneratorOptions>
    {
        public static WebApiClients WebApiClients { get; private set; }
        public AlertDataGenerator(string[] args): base(args)
        {
             WebApiClients = this.GetWebApiClients(this.Options);
        }

        protected override bool GenerateIntervalData(DateTime intervalTime)
        {
            try
            {
                var totalAlerts = this.Options.AlertPerIntervalRandom;
                while(totalAlerts>0)
                {
                    var result = AlertConfigurations.GenerateAlert(intervalTime);
                    if (result) totalAlerts -= 1;
                }
            }
            catch (Exception e)
            {
                ConsoleLogger.Error(e);
            }

            return false;
        }

        private static int Main(string[] args)
        {
            var alertDataGenerator = new AlertDataGenerator(args);
            return (int)alertDataGenerator.Run();
        }

         
    }
}
