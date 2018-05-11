using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiWorldStateless.Entities
{
    public class Class
    {
		public ObjectId Id { get; set; }
		[BsonElement("ProductId")]
		public int ProductId { get; set; }
		[BsonElement("ProductName")]
		public string ProductName { get; set; }
		[BsonElement("Price")]
		public int Price { get; set; }
		[BsonElement("Catagory")]
		public string Category { get; set; }
	}
}
