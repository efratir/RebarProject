using MongoDB.Driver;
using RebarProject.ModelsDB;

namespace RebarProject.DataAccess
{
    public class OrderDBDataAccess:DataAccess
    {
        private const string OrderCollection = "order";

        public Task CreateOrder(OrderDB order)
        {
            var orderCollection = ConnectToMongo<OrderDB>(OrderCollection);
            return orderCollection.InsertOneAsync(order);
        }

        public async Task<List<OrderDB>> GetTodaysOrders()
        {
            var orderCollection = ConnectToMongo<OrderDB>(OrderCollection);
            var results = await orderCollection.FindAsync(o => o.OrderCompleted.Date == DateTime.Today);
            return results.ToList();
        }
    }
}
