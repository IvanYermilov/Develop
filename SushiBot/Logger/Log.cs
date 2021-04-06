using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SushiBot.Logger
{
    static partial class Log
    {
        public static LoggerConfiguration configuration;
        static public int logFileNumber = 1;
        static int currentYear = DateTime.Now.Year;
        static string currentMonth = DateTime.Now.ToString("MM");
        static string currentDay = DateTime.Now.ToString("dd");

        internal static void Debug(string message)
        {
            if (configuration.MinLevel <= LoggerLevels.Debug) WriteLog(LoggerLevels.Debug, message);
        }

        static public void Info(string message)
        {
            if (configuration.MinLevel <= LoggerLevels.Info) WriteLog(LoggerLevels.Info, message);
        }

        static public void Error(string message)
        {
            if (configuration.MinLevel <= LoggerLevels.Error) WriteLog(LoggerLevels.Error, message);
        }

        static private void WriteLog(LoggerLevels logLevel, string message)
        {
            string methName = new StackFrame(2).GetMethod().Name;
            string methNamespace = new StackFrame(2).GetMethod().DeclaringType.Namespace;
            
            while (true)
            {
                FileInfo logFileInfo = new FileInfo($"{configuration.Path}" +
                $"log {currentYear}{currentMonth}{currentDay}_{logFileNumber}.txt");
                if (logFileInfo.Exists && logFileInfo.Length >= configuration.FileSize) logFileNumber++;
                else break;
            }
            FileStream fs = new FileStream($"{configuration.Path}" +
                $"log {currentYear}{currentMonth}{currentDay}_{logFileNumber}.txt", FileMode.Append);
            StreamWriter logFileWriter = new StreamWriter(fs);
            string currenTime = DateTime.Now.ToString("HH:mm:ss");
            string logFileStr = null;
            Console.Write("[");
            switch (logLevel)
            {
                case (LoggerLevels.Debug):
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(LoggerLevels.Debug.ToString());
                    Console.ResetColor();
                    logFileStr = $"[{LoggerLevels.Debug}] ";
                    break;
                case (LoggerLevels.Info):
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(LoggerLevels.Info.ToString());
                    Console.ResetColor();
                    logFileStr = $"[{LoggerLevels.Info}] ";
                    break;
                case (LoggerLevels.Error):
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(LoggerLevels.Error.ToString());
                    Console.ResetColor();
                    logFileStr = $"[{LoggerLevels.Error}] ";
                    break;
            }
            Console.WriteLine($"] {currenTime}; Message: \"{message}\"; Inovked from: {methNamespace}.{methName}");
            logFileStr += $"{currenTime}; Message: \"{message}\"; Inovked from: {methNamespace}.{methName}";
            logFileWriter.Write(logFileStr + "\n");
            logFileWriter.Close();
            fs.Close();
        }
    }
}
