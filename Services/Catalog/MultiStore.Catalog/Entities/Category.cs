using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiStore.Catalog.Entities
{
    public class Category
    {
        [BsonId] //MongoDB için.
        [BsonRepresentation(BsonType.ObjectId)] //ObjectId, uygulamaya bunun bir ID olduğunu bildiriyor.
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
