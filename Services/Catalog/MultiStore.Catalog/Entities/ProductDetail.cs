using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiStore.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId] //MongoDB için.
        [BsonRepresentation(BsonType.ObjectId)] //ObjectId, uygulamaya bunun bir ID olduğunu bildiriyor.
        public string ProductDetailID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }
        public string ProductId { get; set; }

        [BsonIgnore]
        public Product Product { get; set; }
    }
}
