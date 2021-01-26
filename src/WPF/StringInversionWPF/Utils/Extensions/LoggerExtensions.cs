using DataManager.LogRepositories;
using Microsoft.Extensions.Logging;
using StringInversionWPF.Logger;

namespace StringInversionWPF.Utils.Extensions
{
    public static class LoggerExtensions
    {
        public static ILoggerFactory Configure(this ILoggerFactory factory, ILogRepository logRepository)
        {
            factory.AddProvider(new DbLoggerProvider(logRepository));

            return factory;
        }

        public static ILogger LogInfo(this ILogger logger, string info)
        {
            logger.LogInformation(info);

            return logger;
        }
    }
}