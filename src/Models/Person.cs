﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo_API.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string? Name { get; set; }

        public Address? Address { get; set; }
    }
}
