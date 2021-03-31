using System;
using System.Collections.Generic;
using System.IO;
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
            FileStream fs = new FileStream($"{Constants.loggsPath}logFile.txt", FileMode.Append);
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
