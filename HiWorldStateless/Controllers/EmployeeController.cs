using HiWorldStateless.BLL;
using HiWorldStateless.Entities;
using HiWorldStateless.Utilities;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HiWorldStateless.Controllers
{
	[Route("api/Employee")]
   // [Produces("application/json")]

    public class EmployeeController : Controller
    {
		employeesBLL objemployee= new employeesBLL(); 
        private static List<employee> persistentEntities = new List<employee>();
		TelemetryClient appInsightsClient = new TelemetryClient();

		//public EmployeeController()
		//{
		//ConfigReader configReader = new ConfigReader();
		//objemployee = new employeesBLL(); 
		//	}

		[HttpGet("GetAll")]
		public IEnumerable<employee> GetAll()
		{
			return objemployee.GetAllEmployees();
		}


		[HttpGet("{id}")]
        public IActionResult Get(int id)
        {
			if (id == 0)
			{
				appInsightsClient.TrackEvent("id value is zero");
				//ModelState.AddModelError("BadRequest", "Input ids are null or empty");
				//return base.BadRequest(ModelState);
			}
			string exceptionMessage;
			var success= false;
			var startTime = DateTime.UtcNow;
			var timer = System.Diagnostics.Stopwatch.StartNew();

			var sample = new MetricTelemetry("metric name",2);
			//sample.Name = "metric name";
			//sample.Value = 42;
			

			try
			{
				//success = dependency.call();
				
				appInsightsClient.TrackEvent("Entered into main functionality to retrieve device details based on it's id(s)");
				appInsightsClient.TrackPageView("ReviewPage");
				appInsightsClient.TrackTrace("Get employee id");
				appInsightsClient.TrackMetric(sample);

				employee respEmployee = objemployee.GetDetailsById(id);

				return Ok(respEmployee);
				
			}
			catch (SqlException sqlEx)
			{
				exceptionMessage = sqlEx.Message;
				appInsightsClient.TrackException(sqlEx);
			}
			catch (Exception stdEx)
			{
				exceptionMessage = stdEx.Message;
				appInsightsClient.TrackException(stdEx);
			}
			finally
			{
				timer.Stop();
				appInsightsClient.TrackDependency("myDependency", "myCall", startTime, timer.Elapsed, success);

			}
			return base.NotFound(exceptionMessage);
		}

		

		[HttpPost]
        public IActionResult Post([FromBody] employee entity)
        {
            int updatedStatus;
            updatedStatus = objemployee.SetDetailsByPost(entity);
            return Ok(updatedStatus);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(objemployee.DeleteById(id));
        }


    }
}