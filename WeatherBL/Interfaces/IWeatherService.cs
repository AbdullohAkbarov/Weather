using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherBL.Models;

namespace WeatherBL.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherModel> GetCurrentWeatherAsync(string city);
    }
}
