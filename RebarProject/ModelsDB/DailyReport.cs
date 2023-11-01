using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RebarProject.ModelsDB
{
    public class DailyReport
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; }
        public int NumOfOrdersToday { get; set; }
        public decimal DailyProfit { get; set; }
    }
}
