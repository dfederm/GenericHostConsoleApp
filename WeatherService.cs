using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GenericHostConsoleApp;

internal sealed class WeatherService : IWeatherService
{
    private readonly ILogger<WeatherService> _logger;

    private readonly IOptions<WeatherSettings> _weatherSettings;

    public WeatherService(
        ILogger<WeatherService> logger,
        IOptions<WeatherSettings> weatherSettings)
    {
        _logger = logger;
        _weatherSettings = weatherSettings;
    }

    public async Task<IReadOnlyList<int>> GetFiveDayTemperaturesAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching weather...");

        // Simulate some network latency
        await Task.Delay(2000, cancellationToken);

        int[] temperatures = new[] { 76, 76, 77, 79, 78 };
        if (_weatherSettings.Value.Unit.Equals("C", StringComparison.OrdinalIgnoreCase))
        {
            for (int i = 0; i < temperatures.Length; i++)
            {
                temperatures[i] = (int)Math.Round((temperatures[i] - 32) / 1.8);
            }
        }

        _logger.LogInformation("Fetched weather successfully");
        return temperatures;
    }
}
