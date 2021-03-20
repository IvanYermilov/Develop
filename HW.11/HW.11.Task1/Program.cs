using Serilog;
using Serilog.Events;
using System;
using Task_1.UserInterface;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(@".\log\log-.txt", LogEventLevel.Information, rollingInterval: RollingInterval.Hour)
                .CreateLogger();

            Type t = typeof(Program);
            Log.Information($"Application {t.Namespace} has been started");
            ConsoleIO consoleIO = new ConsoleIO();
            while(!consoleIO.IsProgramMustStop())
            {
                consoleIO.PickDatabaseOperation();
            }
            Log.Information($"Application {t.Namespace} has been stopped");
        }
    }
}
