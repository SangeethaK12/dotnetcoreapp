using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HiWorldStateless.DAO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HiWorldStateless
{
    public class Startup
	{
		public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

		}

		public IConfiguration Configuration { get;  }

		public IConfigurationRoot configuration {get;set;}

		

	// This method gets called by the runtime. Use this method to add services to the container.
	public void ConfigureServices(IServiceCollection services)
        {
			services.AddTransient<EmployeeMongoDAO>();
		
			services.AddMvc();
			//services.AddApplicationInsightsTelemetry();
			//var configBuilder = new ConfigurationBuilder()
				//.SetBasePath(env.ContentRootPath)
				//.AddEnvironmentVariables();
			//var Configuration = configBuilder.Build();
		//	services.AddApplicationInsightsTelemetry(Configuration);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

				if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

			
			app.UseMvc();
        }
    }
}
