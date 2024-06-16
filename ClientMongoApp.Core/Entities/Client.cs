using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ClientMongoApp.Core.Entities
{
    public record Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Last_name { get; set; }
        public string Document_id { get; set; }
        public string Document_type { get; set; }
        public string Address { get; set; }
        public DateTime Creation_date { get; set; }
    };
}
