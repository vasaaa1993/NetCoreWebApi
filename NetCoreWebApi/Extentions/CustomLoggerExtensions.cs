using Microsoft.Extensions.Logging;
using NetCoreWebApi.Logger;
using System;

namespace NetCoreWebApi.Extentions
{
    public static class CustomLoggerExtensions
    {
		public static ILoggerFactory AddCustomLogger(this ILoggerFactory loggerFactory, CustomLoggerConfiguration config)
		{
			loggerFactory.AddProvider(new CustomLoggerProvider(config));
			return loggerFactory;
		}
		public static ILoggerFactory AddCustomLogger(this ILoggerFactory loggerFactory)
		{
			var config = new CustomLoggerConfiguration();
			return loggerFactory.AddCustomLogger(config);
		}
		public static ILoggerFactory AddCustomLogger(this ILoggerFactory loggerFactory, Action<CustomLoggerConfiguration> configure)
		{
			var config = new CustomLoggerConfiguration();
			configure(config);
			return loggerFactory.AddCustomLogger(config);
		}
	}
}
