using HiWorldStateless.DAO;
using HiWorldStateless.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiWorldStateless.BLL
{
	public enum BackEndDB
	{
		SQL = 0,
		MONGO
	}

	internal class DAOClientFactory
    {
		public static IBackendDAO GetDBClient(BackEndDB dbChoice)
		{
			IBackendDAO backendDAO;

			switch (dbChoice)
			{
				case BackEndDB.SQL:
					backendDAO = new EmployeeSQLDAO();
					break;
				case BackEndDB.MONGO:
					backendDAO = new EmployeeMongoDAO();
					break;
				default:
					backendDAO = new EmployeeMongoDAO();
					break;
			}

			return backendDAO;
		}

	}
}
