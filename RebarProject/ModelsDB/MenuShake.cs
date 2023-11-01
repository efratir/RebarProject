using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RebarProject.ModelsDB
{
    public class MenuShake
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal priceForS { get; set; }
        public decimal priceForM { get; set; }
        public decimal priceForL { get; set; }

    }
}
