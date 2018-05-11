using System;
using System.Collections.Generic;
using System.Fabric;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.ServiceFabric;
using HiWorldStateless.Utilities;

namespace HiWorldStateless
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance. 
    /// </summary>
    internal sealed class HiWorldStateless : StatelessService
    {
        public HiWorldStateless(StatelessServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (like tcp, http) for this service instance.
        /// </summary>
        /// <returns>The collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[]
            {
                new ServiceInstanceListener(serviceContext =>
                    new HttpSysCommunicationListener(serviceContext, "ServiceEndpoint", (url, listener) =>
                    {
						
                        ServiceEventSource.Current.ServiceMessage(serviceContext, $"Starting HttpSys on {url}");

                        return new WebHostBuilder()
                                    .UseHttpSys()
                                    .ConfigureServices(
                                        services => services
										.AddSingleton<StatelessServiceContext>(serviceContext)
										.AddSingleton<ITelemetryInitializer>((serviceProvider) => new FabricTelemetryInitializer()))
										.UseContentRoot(Directory.GetCurrentDirectory())
										.UseStartup<Startup>()
										.UseApplicationInsights(ConfigReader.ApplicationInsightsKey)
										.UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
										.UseUrls(url)
										.Build();
                    }))
            };
        }
    }
}
