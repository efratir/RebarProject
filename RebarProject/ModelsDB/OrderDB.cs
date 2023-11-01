using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RebarProject.Models;

namespace RebarProject.ModelsDB
{
    public class OrderDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; }
        public string CustomerName { get; set; }
        public DateTime OrderCreated { get; set; }
        public DateTime OrderCompleted { get; set; }
        public decimal SumOfPrices { get; set; }
        public List<Guid> ShakeIds { get; set; }

        public OrderDB(Order order)
        {
            Id = order.Id;
            CustomerName = order.CustomerName;
            OrderCreated = order.OrderDate;
            OrderCompleted = DateTime.Now;
            SumOfPrices = order.SumOfPrices;
            ShakeIds = new List<Guid>();
            foreach (var shake in order.Shakes)
            {
                ShakeIds.Add(shake.Id);
            }
        }

        public OrderDB(string customerName, decimal sumOfPrices)
        {
            Id = Guid.NewGuid();
            CustomerName = customerName;
            OrderCreated = DateTime.Now;
            SumOfPrices = sumOfPrices;
            ShakeIds = new List<Guid>() { new Guid(), new Guid() };
        }
    }
}
