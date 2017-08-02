using System;
using Microsoft.Extensions.Logging;

namespace NetCoreWebApi.Logger
{
	public class CustomLoggerConfiguration
	{
		public LogLevel LogLevel { get; set; } = LogLevel.Information;
		public int EventId { get; set; } = 0;
	}
}
