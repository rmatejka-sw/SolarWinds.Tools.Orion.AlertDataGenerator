using System;

namespace SolarWinds.Tools.DataGeneration.Helpers
{
    public static class ConsoleHelper
    {
        public static void RewriteLine(string text)
        {
            var top = Console.CursorTop;
            Console.WriteLine(text);
            Console.CursorTop = top;
            Console.CursorLeft = 0;
        }
    }
}
