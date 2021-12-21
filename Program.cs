using System.Reflection;
using GenericHostConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder(args)
    .UseContentRoot(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
    .ConfigureLogging(logging =>
    {
        // Add any 3rd party loggers like NLog or Serilog
    })
    .ConfigureServices((hostContext, services) =>
    {
        services
            .AddHostedService<ConsoleHostedService>()
            .AddSingleton<IWeatherService, WeatherService>();

        services.AddOptions<WeatherSettings>().Bind(hostContext.Configuration.GetSection("Weather"));
    })
    .RunConsoleAsync();
