using RebarProject.Models;
using MongoDB.Driver;
using RebarProject.ModelsDB;

namespace RebarProject.DataAccess
{
    public class ShakeDataAccess:DataAccess
    {
        private const string ShakeCollection = "shake";

        public Task CreateShake(MenuShake shake)
        {
            var shakeCollection = ConnectToMongo<MenuShake>(ShakeCollection);
            return shakeCollection.InsertOneAsync(shake);
        }

        public async Task<List<MenuShake>> GetAllShakes()
        {
            var shakesCollection = ConnectToMongo<MenuShake>(ShakeCollection);
            var results = await shakesCollection.FindAsync(_ => true);
            return results.ToList();
        }
    }
}
