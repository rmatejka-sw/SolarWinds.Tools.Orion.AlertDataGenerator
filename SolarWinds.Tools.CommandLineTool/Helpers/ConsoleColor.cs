using System;

namespace SolarWinds.Tools.CommandLineTool.Helpers
{
    public class ForegroundColor : IDisposable
    {
        private ConsoleColor _currentColor;

        public static ForegroundColor Red() => new ForegroundColor(ConsoleColor.Red);
        public static ForegroundColor Yellow() => new ForegroundColor(ConsoleColor.Yellow);
        public static ForegroundColor Green() => new ForegroundColor(ConsoleColor.Green);
        public static ForegroundColor DarkGray() => new ForegroundColor(ConsoleColor.DarkGray);
        public static ForegroundColor Purple() => new ForegroundColor(ConsoleColor.Magenta);
        public static ForegroundColor StatusColor(int status) => new ForegroundColor(status);

        public ForegroundColor(ConsoleColor color)
        {
            _currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
        }
        public ForegroundColor(int status)
        {
            _currentColor = Console.ForegroundColor;
            switch (status)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 2:
                case 14:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
        }
        public void Dispose()
        {
            Console.ForegroundColor = _currentColor;
        }
    }
}
