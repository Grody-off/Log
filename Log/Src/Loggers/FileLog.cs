using System;
using System.IO;

namespace Log
{
    public class FileLog : ILogger
    {
        public void Log(string err)
        {
            if (string.IsNullOrEmpty(err))
            {
                throw new ArgumentNullException(err,"Error message can not be null or empty");
            }
            using StreamWriter file = new("err.txt", append: true);
            file.WriteLine(err);
        }
    }
}