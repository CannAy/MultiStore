using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiStore.Catalog.Entities
{
    public class ProductImage
    {
        [BsonId] //MongoDB için.
        [BsonRepresentation(BsonType.ObjectId)] //ObjectId, uygulamaya bunun bir ID olduğunu bildiriyor.
        public string ProductImageID { get; set; }
        public string Image2 { get; set; }
        public string Image1 { get; set; }
        public string Image3 { get; set; }
        public string ProductId { get; set; }

        [BsonIgnore]
        public Product Product { get; set; }
    }
}
