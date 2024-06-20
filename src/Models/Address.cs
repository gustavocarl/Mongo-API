using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo_API.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string? Street { get; set; }
    }
}