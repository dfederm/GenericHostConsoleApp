namespace GenericHostConsoleApp;

internal interface IWeatherService
{
    Task<IReadOnlyList<int>> GetFiveDayTemperaturesAsync(CancellationToken cancellationToken);
}