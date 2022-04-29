using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarWinds.Tools.CommandLineTool.Helpers
{
    public static class ConsoleLogger
    {

        public static void Error(Exception ex)
        {
            using (ForegroundColor.Red())
            {
                Console.Error.WriteLine(ex);
            }
        }

        public static void Error(string message)
        {
            using (ForegroundColor.Red())
            {
                Console.Error.WriteLine(message);
            }
        }

        public static void Warning(string message)
        {
            using (ForegroundColor.Yellow())
            {
                Console.Error.WriteLine(message);
            }
        }

        public static void Success(string message)
        {
            using (ForegroundColor.Green())
            {
                Console.Error.WriteLine(message);
            }
        }

        public static void Info(string message)
        {
            using (ForegroundColor.DarkGray())
            {
                Console.Error.WriteLine(message);
            }
        }
    }
}
