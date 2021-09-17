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
using WeatherBL.Models;
using WeatherBL.Validators;
using WeatherDAL;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : Controller
    {
        private WeatherService _service;
        private readonly IConfiguration configuration;
        private ILog log;

        public WeatherController()
        {
            _service = new WeatherService(new WeatherProvider(new HttpClient(), configuration["url"], configuration["appid"]), new CityValidator());
        }

        [Route("GetWeather")]
        [HttpGet]
        public async Task<string> GetWeather(string city)
        {
            var response = await _service.GetCurrentWeatherAsync(city);
            if (response.IsSuccess is false)
            {
                log.Error(response.Error);

                return response.Error;
            }

            log.Info($"The weather in {response.City} City right now is {response.Temperature}");

            return response.Temperature.ToString();
        }
    }
}
