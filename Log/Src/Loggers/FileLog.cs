using System.IO;

namespace Log
{
    public class FileLog : ILogger
    {
        public void Log(string err)
        {
            using StreamWriter file = new("err.txt", append: true);
            file.WriteLine(err);
        }
    }
}