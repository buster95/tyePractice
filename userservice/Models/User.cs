using System;
using MongoDB.Bson.Serialization.Attributes;

namespace userservice.Models {
    public class User {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("lastname")]
        public string LastName { get; set; }

        [BsonElement("birthday")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? FechaNacimiento { get; set; }
    }
}