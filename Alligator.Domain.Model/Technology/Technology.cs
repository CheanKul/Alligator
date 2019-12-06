using Microsoft.AspNetCore.Http;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Alligator.Domain.Model
{
    public class Technology
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string TechnologyName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
