using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiWorldStateless.Entities;
using HiWorldStateless.Utilities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace HiWorldStateless.DAO
{

	public class EmployeeMongoDAO : IBackendDAO
	{
		MongoClient _client;
		MongoServer _server;
		MongoDatabase mydb;
		const string collectionName = "Employees";

		public EmployeeMongoDAO()
		{
			_client = new MongoClient(ConfigReader.MongoDb);
			_server = _client.GetServer();
			mydb = _server.GetDatabase(ConfigReader.DbName);
		}

		public IEnumerable<employee> GetAllEmployees()
		{	
			var test = mydb.GetCollection<employee>(collectionName).FindAll();
			return test;
		}


		public int DeleteById(int id)
		{
			var res = Query<employee>.EQ(e => e.Empid, id);
			var opr= mydb.GetCollection<employee>(collectionName).Remove(res);
			return 1;
		}

		public employee GetDetailsById(int id)
		{
			var res = Query<employee>.EQ(p => p.Empid, id);
			return mydb.GetCollection<employee>(collectionName).FindOne(res);

			}

		public employee GetDetailsByName(string name)
		{
			var res = Query<employee>.EQ(p => p.Name, name);
			return mydb.GetCollection<employee>(collectionName).FindOne(res);

			}

		public int SetDetailsByPost(employee p)
		{
			 mydb.GetCollection<employee>(collectionName).Save(p);
			return 1;



		}

		
	}
}
