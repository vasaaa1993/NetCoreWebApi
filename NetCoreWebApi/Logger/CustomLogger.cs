﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Logger
{
    public class CustomLogger : ILogger
    {
		private readonly string _name;
		private readonly CustomLoggerConfiguration _config;

		public CustomLogger(string name, CustomLoggerConfiguration config)
		{
			_name = name;
			_config = config;
		}

		public IDisposable BeginScope<TState>(TState state)
		{
			return null;
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return logLevel == _config.LogLevel;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			if (!IsEnabled(logLevel))
			{
				return;
			}

			if (_config.EventId == 0 || _config.EventId == eventId.Id)
			{
				Console.WriteLine($"Custom logger: {logLevel.ToString()} - {eventId.Id} - {_name} - {formatter(state, exception)}");
			}
		}
	}
}
