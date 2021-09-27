using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherBL;
using WeatherBL.Interfaces;
using WeatherBL.Models;
using WeatherBL.Validators;
using WeatherDAL;
using WeatherDAL.Entities;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : Controller
    {
        private IWeatherService _service;

        public WeatherController(IWeatherService service)
        {
            _service = service;
        }

        [Route("GetWeather")]
        [HttpGet]
        public async Task<string> GetWeather(string city)
        {
            var response = await _service.GetCurrentWeatherAsync(city);
            if (response.IsSuccess is false)
            {
                return response.Error;
            }

            return response.Temperature.ToString();
        }

        [Route("GetHistoryWeather")]
        [HttpGet]
        public async Task<Weather> GetHistoryWeather(string city)
        {
            var response = await _service.GetCurrentWeatherHistoryAsync(city);

            return response;
        }
    }
}
