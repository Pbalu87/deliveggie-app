using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DeliVeggie.Shared.Models.Entities
{
    public class PriceReduction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int DayOfWeek { get; set; }
        public double Reduction { get; set; }
    }
}