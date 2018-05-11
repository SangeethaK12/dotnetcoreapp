
using HiWorldStateless.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiWorldStateless.DAO
{
    public interface IBackendDAO
    {
		IEnumerable<employee> GetAllEmployees();

		employee GetDetailsById(int id);

		int SetDetailsByPost(employee entity);

		int DeleteById(int id);

	}
}
