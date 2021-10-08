using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherDAL.Entities;
using WeatherDAL.Models;

namespace WeatherDAL
{
    public interface IWeatherProvider
    {     
        Task<WeatherResponse> GetWeatherAsync(string city);
        Task<List<Weather>> GetWeatherHistoryAsync(string city);
        Task InsertWeatherAsync(string city, double temp);
    }
}
