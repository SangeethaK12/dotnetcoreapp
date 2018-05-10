using System;
using System.Collections.Generic;
using System.Fabric;
using System.Fabric.Description;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace HiWorldStateless.Utilities
{
    public class ConfigReader
    {
		const string configKey = "Config";
		const string sectionConfigKey = "WebAPI";
		const string connectionStringConfigKey = "ConnectingStringSecretName";
		const string appInsightsConfigKey = "ApplicationInsightsKey";
		const string MongoConnectionConfigKey = "MongoDb";
		const string MongoDbName = "DbName";


		private static System.Fabric.ICodePackageActivationContext activationContext = FabricRuntime.GetActivationContext();
		private static ConfigurationPackage configPackage = activationContext.GetConfigurationPackageObject(configKey);
		private static ConfigurationSection configSection = configPackage.Settings.Sections.Contains(sectionConfigKey) ? configPackage.Settings.Sections[sectionConfigKey] : null;
		//private IOptions<AllConfiguration> _configs;
		 
		public static string ConnectionStringSecretName
		{
			get { return configSection.Parameters[connectionStringConfigKey].Value; }
		}

		public static string ApplicationInsightsKey
		{
			get { return configSection.Parameters[appInsightsConfigKey].Value; }
		}

		public static string MongoDb 
		{
			get { return configSection.Parameters[MongoConnectionConfigKey].Value; }
		}

		public static string DbName
		{
			get { return configSection.Parameters[MongoDbName].Value; }
		}

		public ConfigReader()
		{
			activationContext = FabricRuntime.GetActivationContext();
			configPackage = activationContext.GetConfigurationPackageObject(configKey);
			configSection = configPackage.Settings.Sections.Contains(sectionConfigKey) ? configPackage.Settings.Sections[sectionConfigKey] : null;
		}

		//public DataAccessObject()
		//{

		//SqlHelper.ConnectionString = ConnectionStringSecretName;

		// SqlHelper.ConnectionString = @"Server=DESKTOP-3BKH1B5\SQLEXPRESS;Database=EmployeeDetails;User Id=sa;
		//Password=haihello23;";
		//}
	}
}

