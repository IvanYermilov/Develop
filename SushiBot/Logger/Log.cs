using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SushiBot.Logger
{
    static partial class Log
    {
        public static LoggerConfiguration Configuration;
        static public int logFileNumber = 1;
        static int currentYear = DateTime.Now.Year;
        static string currentMonth = DateTime.Now.ToString("MM");
        static string currentDay = DateTime.Now.ToString("dd");

        static public void Info(string message)
        {
            FileInfo logFile = new FileInfo($"{Constants.loggsPath}" +
                $"log {currentYear}{currentMonth}{currentDay}_{logFileNumber}.txt");
            if (logFile.Exists && logFile.Length >= Constants.logFileLimit) logFileNumber++;
            FileStream fs = new FileStream($"{Constants.loggsPath}" +
                $"log {currentYear}{currentMonth}{currentDay}_{logFileNumber}.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            string currenTime = DateTime.Now.ToString("HH:mm:ss");
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Info");
            Console.ResetColor();
            Console.WriteLine($"] {currenTime} message: \"{message}\"");
            string str = $"[Info] {currenTime} message: \"{message}\"";
            sw.Write(str+"\n");
            sw.Close();
            fs.Close();
        }
    }
}
