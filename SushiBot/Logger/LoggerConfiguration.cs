using System.IO;

namespace SushiBot.Logger
{
    public class LoggerConfiguration 
    {
        static private string _path;
        static private LoggerLevels _minLevel;
        static private uint _fileSize;

        public LoggerConfiguration()
        {
            _path = ".";
            _minLevel = LoggerLevels.Info;
            _fileSize = 30;
        }

        public LoggerConfiguration(string path, LoggerLevels minLevel = LoggerLevels.Info, uint fileSize = 30)
        {
            _path = path;
            _minLevel = minLevel;
            _fileSize = fileSize;
        }
    }

}
