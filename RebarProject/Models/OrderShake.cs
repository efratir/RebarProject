using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RebarProject.Models
{
    public class OrderShake
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string NameShake { get; set; }
        public Size size { get; set; }
        public decimal Price { get; set; }

        public enum Size
        {
            S,
            M,
            L,
        }

    }  
}
