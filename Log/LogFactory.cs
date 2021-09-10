namespace Log
{
    public class LogFactory
    {
        public enum LoggerType
        {
            File,
            Database,
            Console
        }
        public static ILogger GetLogger(LoggerType type)
        {
            switch (type)
            {
                case LoggerType.Database:
                    return new DbLog();
                case LoggerType.Console:
                    return new ConsoleLog();
                case LoggerType.File:
                    return new FileLog();
                default:
                    return new DbLog();
            }
        }
    }
}