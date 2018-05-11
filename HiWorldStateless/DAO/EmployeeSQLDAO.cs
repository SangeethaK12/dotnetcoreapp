using HiWorldStateless.Entities;
using HiWorldStateless.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HiWorldStateless.DAO
{
	public class EmployeeSQLDAO : IBackendDAO
	{
		public EmployeeSQLDAO()
		{
			SqlHelper.ConnectionString = ConfigReader.ConnectionStringSecretName;
		}

		public employee GetDetailsById(int id)
		{
			employee emp = new employee();
			emp.Empid = id;
			SqlParameter IdParam = SqlHelper.FormSqlParameter("@Id", id, SqlDbType.Int);

			using (SqlDataReader deviceReader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "dbo.GetEmpId", IdParam))
			{
				if (deviceReader != null)
				{
					while (deviceReader.Read())
					{
						var str = (string)(deviceReader["Name"]);
						emp.Name = str;
						var sal = (int)(deviceReader["Salary"]);
						emp.Salary = sal;
						var dt = (DateTime)(deviceReader["DOB"]);
						emp.DOB = dt;
					}
				}
			}

			return emp;
		}

		public int SetDetailsByPost(employee entity)
		{
			employee emp = new employee();
			emp.Id = entity.Id;
			emp.Name = entity.Name;
			emp.DOB = entity.DOB;
			emp.Salary = entity.Salary;
			SqlParameter idParam = SqlHelper.FormSqlParameter("@Id", emp.Id, SqlDbType.Int);
			SqlParameter nameParam = SqlHelper.FormSqlParameter("@Name", emp.Name, SqlDbType.VarChar);
			SqlParameter dobParam = SqlHelper.FormSqlParameter("@DOB", emp.DOB, SqlDbType.DateTime);
			SqlParameter salaryParam = SqlHelper.FormSqlParameter("@Salary", emp.Salary, SqlDbType.Int);
			return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "dbo.UpdateEmpId", idParam, nameParam, dobParam, salaryParam);
		}

		public int DeleteById(int id)
		{
			employee emp = new employee();
			emp.Empid = id;
			SqlParameter idParam = SqlHelper.FormSqlParameter("@Id", id, SqlDbType.Int);
			return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "dbo.DeleteEmpId", idParam);
		}

		public IEnumerable<employee> GetAllEmployees()
		{
			throw new NotImplementedException();
		}
	}
}
