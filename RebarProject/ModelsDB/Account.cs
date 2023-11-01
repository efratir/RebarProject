using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RebarProject.Models;

namespace RebarProject.ModelsDB
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public List<Order> Orders { get; set; }
        public decimal SumOfOrders { get; set; }
        public string CustomerName { get; set; }

        public Account()
        {
            Id = Guid.NewGuid();
            Orders = new List<Order>();          
        }
    }
}
