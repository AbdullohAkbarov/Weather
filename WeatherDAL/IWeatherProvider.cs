using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WeatherDAL.Models;

namespace WeatherDAL
{
    public interface IWeatherProvider
    {
        WeatherResponse CallOpenWeather(string url);
    }
}
