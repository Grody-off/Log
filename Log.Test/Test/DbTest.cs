using System;
using MongoDB.Bson;
using MongoDB.Driver;
using Xunit;

namespace Log.Test
{
    public class DbTest
    {
        [Fact]
        public void WriteInDb()
        {
            //Arrange
            var dl = new DbLog();
            var collection = dl.GetCollection();
            var error = new Guid();
            var filter = new BsonDocument{ {"Error_message", error.ToString()}};
            var expected = new BsonElement("Error_message", error.ToString());
            
            //Act
            dl.Log(error.ToString());
            var doc = collection.Find(filter).ToList();
            
            //Asserts
            foreach (var d in doc)
            {
                d.TryGetElement("Error_message", out var actual);
                Assert.Equal(expected, actual);
                collection.DeleteOne(d);
            }
        }
        [Fact]
        public void WriteNull()
        {
            //Arrange
            var dl = new DbLog();
 
            //Act & Asserts
            Assert.Throws<ArgumentNullException>(() => dl.Log(null));
        }
    }
}