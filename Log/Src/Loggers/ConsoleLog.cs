using System;

namespace Log
{
    public class ConsoleLog : ILogger
    {
        public void Log(string err)
        {
            Console.WriteLine(err);
        }
    }
}