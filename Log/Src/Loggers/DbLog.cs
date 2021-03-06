using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Log
{
    public class DbLog : ILogger
    {
        public IMongoCollection<BsonDocument> GetCollection()  
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://grody:1234@log.vm4ns.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("Log");
            var collection = database.GetCollection<BsonDocument>("Log");
            return collection;
        }
        public void Log(string err)
        {
            if (string.IsNullOrEmpty(err))
            {
                throw new ArgumentNullException(err,"Error message can not be null or empty");
            }
            var collection = GetCollection();
            var document = new BsonDocument
            {
                { "name", "Error" },
                { "Error_message", err },
                {"Date",new BsonDateTime(DateTime.Now)}
            };
            collection.InsertOne(document);
        }
    }
}