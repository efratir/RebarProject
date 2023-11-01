using MongoDB.Driver;

namespace RebarProject.DataAccess
{
    public class DataAccess
    {
        private const string ConnectionString = "mongodb://127.0.0.1:27017";
        private const string DataBaseName = "Rebar";

        protected IMongoCollection<T>ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DataBaseName);
            return db.GetCollection<T>(collection);
        }
    }
}
