using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AzureFunctionWithSettings
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureAppConfiguration(builder =>
                {
                    builder.AddJsonFile("appsettings.json", true, true)
                        .AddUserSecrets(Assembly.GetExecutingAssembly(), true);
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