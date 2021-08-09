using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;

namespace AzureFunctionWithSettings
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureAppConfiguration(builder =>
                {
                    builder.AddUserSecrets(Assembly.GetExecutingAssembly(), true);
                })
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(services =>
                {
                    services.AddOptions<ExampleServiceOptions>().Configure<IConfiguration>((settings, configuration) =>
                    {
                        configuration.GetSection(nameof(ExampleServiceOptions)).Bind(settings);
                    });
                })
                .Build();

            host.Run();
        }
    }
}