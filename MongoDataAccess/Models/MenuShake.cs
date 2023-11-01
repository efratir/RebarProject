using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace RebarProject.Models
{
    public class MenuShake
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }
        public double priceForS { get; set; }
        public double priceForM { get; set; }
        public double priceForL { get; set; }

    }
}
