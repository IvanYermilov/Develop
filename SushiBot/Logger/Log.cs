using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBot.Logger
{
    static partial class Log
    {
        public static LoggerConfiguration Configuration;



        static public void Info(string message)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Info");
            Console.ResetColor();
            Console.Write($"] {DateTime.Now.ToString("HH:mm:ss")} message: \"{message}\"");
        }
    }
}
