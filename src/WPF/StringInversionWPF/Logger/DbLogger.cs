using System;
using DataManager.LogRepositories;
using Microsoft.Extensions.Logging;

namespace StringInversionWPF.Logger
{
    public class DbLogger : ILogger
    {
        private readonly ILogRepository _logRepository;

        public DbLogger(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (logLevel == LogLevel.None) return;
            if (formatter == null) return;

            _logRepository.AddLog(formatter(state, exception));
        }
    }
}