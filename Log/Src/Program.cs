using System;
using static Log.LogFactory;

namespace Log
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbLogger = GetLogger(LoggerType.Database);
            dbLogger.Log("Error");

            var fileLogger = GetLogger(LoggerType.File);
            fileLogger.Log("Error");

            var consoleLogger = GetLogger(LoggerType.Console);
            consoleLogger.Log("Error");

            Console.ReadKey();
        }
    }
}
