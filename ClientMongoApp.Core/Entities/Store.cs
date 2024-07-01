using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClientMongoApp.Core.Entities
{
    public class Store
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; init; }
        public string Code { get; init; }
        public string Address { get; init; }
        public string LeaderId { get; init; }

        public string ConnectionStatus { get; init; }
    }
}
