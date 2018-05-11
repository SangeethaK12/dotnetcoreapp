using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;

namespace HiWorldStateless.Entities
{
	public class employee
	{
		[BsonElement("_Id", Order = 0)]
		public ObjectId Id { get; set; }       
		[BsonElement("Id", Order = 1)] 
		public int Empid { get; set; }  
		[BsonElement("Name", Order = 2)]
		public String Name { get; set; }
		[BsonElement("DOB", Order = 3)]
		public DateTime DOB { get; set; }
		[BsonElement("Salary", Order = 4)]
		public int Salary { get; set; }
		
	}

	
}
