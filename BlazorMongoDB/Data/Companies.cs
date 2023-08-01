using Microsoft.AspNetCore.Routing.Constraints;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorMongoDB.Data
{
    public class Companies
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string Name { get; set; }    

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string FileName { get; set; }

        public byte Image_Data { get; set; }

    }
}
