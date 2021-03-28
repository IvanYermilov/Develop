using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBot
{
    class Logger
    {
        //ctor must contain path, minLevel, fileSize
        private string _path;
        private LogLevels _minLevel;
        private uint _fileSize;

        public Logger(string path, LogLevels minLevel = LogLevels.Info, uint fileSize = 30)
        {
            _path = path;
            _minLevel = minLevel;
            _fileSize = fileSize;
        }

        public void Info(string message)
        {
            Console.WriteLine("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Info");
            Console.ResetColor();
            Console.Write($"] {DateTime.Now.TimeOfDay}");
        }
    }
    enum LogLevels
    {
        Debug = 0,
        Info = 1,
        Error = 2
    }
}
