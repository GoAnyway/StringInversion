using AutoMapper;
using Database;
using DataManager.LogRepositories;
using DataManager.StringInversionRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StringInversionWPF.Logger;
using StringInversionWPF.Utils.MapperProfiles;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace StringInversionWPF.Utils.Extensions.HostBuilderExtensions
{
    public static class DefaultHostBuilderExtensions
    {
        public static IHostBuilder AddConfiguration(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration(c =>
            {
                c.AddJsonFile("appsettings.json");
                c.AddEnvironmentVariables();
            });

            return host;
        }

        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<StringInversionDbContext>(_ => _.UseSqlServer(connectionString));
            });

            return host;
        }

        public static IHostBuilder AddAutoMapper(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IConfigurationProvider>(_ =>
                    new MapperConfiguration(cfg => cfg.AddProfiles(new Profile[]
                    {
                        new StringInversionProfile()
                    })));

                services.AddSingleton<IMapper, Mapper>();
            });

            return host;
        }

        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IStringInversionRepository, DbStringInversionRepository>();
                services.AddSingleton<ILogRepository, DbLogRepository>();
            });

            return host;
        }

        public static IHostBuilder AddLogger(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var logRepository = serviceProvider.GetService<ILogRepository>();

                services.AddLogging(_ => _.AddProvider(new DbLoggerProvider(logRepository)));
            });

            return host;
        }
    }
}