using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherBL.Models;
using WeatherDAL.Entities;

namespace WeatherBL.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherModel> GetCurrentWeatherAsync(string city);
        Task<List<Weather>> GetCurrentWeatherHistoryAsync(string city);
    }
}
