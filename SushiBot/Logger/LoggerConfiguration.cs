using System.IO;

namespace SushiBot.Logger
{
    public class LoggerConfiguration 
    {
        static private string _path;
        static private LoggerLevels _minLevel;
        static private uint _fileSize;
        private const string defaultLogPath = ".";
        private const uint defaultFileSize = 30;

        public string Path
        {
            get { return _path; }
            private set { _path = value; }
        }

        public LoggerLevels MinLevel
        {
            get { return _minLevel; }
            private set { _minLevel = value; }
        }

        public uint FileSize
        {
            get { return _fileSize; }
            private set { _fileSize = value; }
        }

        public LoggerConfiguration()
        {
            
            _path = defaultLogPath;
            _minLevel = LoggerLevels.Info;
            _fileSize = 30000;
        }

        public LoggerConfiguration(string path = defaultLogPath, LoggerLevels minLevel = LoggerLevels.Info, uint fileSize = defaultFileSize)
        {
            _path = path;
            _minLevel = minLevel;
            _fileSize = fileSize*1000;
        }
    }

}
