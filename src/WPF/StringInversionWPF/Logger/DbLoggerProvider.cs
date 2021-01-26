using DataManager.LogRepositories;
using Microsoft.Extensions.Logging;

namespace StringInversionWPF.Logger
{
    public class DbLoggerProvider : ILoggerProvider
    {
        private readonly ILogRepository _logRepository;

        public DbLoggerProvider(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public ILogger CreateLogger(string categoryNames) =>
            new DbLogger(_logRepository);

        public void Dispose()
        {
        }
    }
}