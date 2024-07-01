using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ClientMongoApp.Core.Entities
{
    public record Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; init; }
        public string Name { get; init; }
        public string Last_name { get; init; }
        public string Document_id { get; init; }
        public string Document_type { get; init; }
        public string Address { get; init; }
        public string Photo { get; init; }
        public DateTime Creation_date { get; init; }
    };
}
