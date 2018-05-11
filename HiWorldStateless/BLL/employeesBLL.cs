using HiWorldStateless.DAO;
using HiWorldStateless.Entities;
using HiWorldStateless.Utilities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiWorldStateless.BLL
{
    public class employeesBLL
    {
		IBackendDAO backendDao;
		string choice = "SQL";

		public employeesBLL()
		{
			BackEndDB dbChoice = choice == "MONGO" ? BackEndDB.MONGO : BackEndDB.SQL;
			this.backendDao = DAOClientFactory.GetDBClient(dbChoice);
		}

		public employee GetDetailsById(int id)
		{
			 return backendDao.GetDetailsById(id);

		}
		public int SetDetailsByPost(employee emp)
		{
			return backendDao.SetDetailsByPost(emp);
		}
		public int DeleteById(int id)
		{
			return backendDao.DeleteById(id);
		}

		public IEnumerable<employee> GetAllEmployees()
		{
			return this.backendDao.GetAllEmployees();
		}
	}
}
