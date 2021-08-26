using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherBL.Models;

namespace WeatherBL
{
    public interface IWeatherService
    {
        Task<WeatherModel> GetCurrentWeather(string city);
    }
}
