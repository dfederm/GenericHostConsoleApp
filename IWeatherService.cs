using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericHostConsoleApp
{
    internal interface IWeatherService
    {
        Task<IReadOnlyList<int>> GetFiveDayTemperaturesAsync();
    }
}