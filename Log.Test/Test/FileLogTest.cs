using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Log.Test
{
    public class FileLogTest
    {
        [Fact]
        public void CreateFileIfFileIsNotFounded()
        {
            //Arrange
            File.Delete("err.txt");
            var fl = new FileLog();
            
            //Act
            fl.Log("never mind");

            //Asserts
            Assert.True(File.Exists("err.txt"));
        }
        
        [Fact]
        public void CheckWriteInFile()
        {
            //Arrange
            var errMessage = "check write in file";
            var fl = new FileLog();

            //Act
            fl.Log(errMessage);
            var lastLine = File.ReadLines("err.txt").Last();
            
            //Asserts
            Assert.Equal(errMessage, lastLine);
        }
        
        [Fact]
        public void WriteNull()
        {
            //Arrange
            var fl = new FileLog();
 
            //Act & Asserts
            Assert.Throws<ArgumentNullException>(() => fl.Log(null));
        }
    }
}