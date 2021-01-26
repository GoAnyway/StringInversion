using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StringInversionWPF.ViewModels;

namespace StringInversionWPF.Utils.Extensions.HostBuilderExtensions
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services => { services.AddSingleton<MainViewModel>(); });

            return host;
        }
    }
}