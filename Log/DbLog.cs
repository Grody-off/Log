using MongoDB.Bson;
using MongoDB.Driver;

namespace Log
{
    public class DbLog : ILogger
    {
        public void Log(string err)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://grody:1234@log.vm4ns.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("Log");
            var collection = database.GetCollection<BsonDocument>("Log");

            var document = new BsonDocument
            {
                { "name", "Error" },
                { "Error_message", err }
            };
            collection.InsertOne(document);
        }
    }
}