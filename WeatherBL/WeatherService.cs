﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherBL.Models;
using WeatherDAL;

namespace WeatherBL
{
    public class WeatherService : IWeatherService
    {
        private IWeatherProvider provider;
        private WeatherModel weather;

        public WeatherService(IWeatherProvider provider)
        {
            this.provider = provider;
        }

        public async Task<WeatherModel> GetCurrentWeatherAsync(string city)
        {
            try 
            {
                var response = await provider.GetWeatherAsync(city);
                if (response != null)
                {
                    weather = new WeatherModel { City = city, Temperature = DegreeConverter.GetCelsius(response.Main.Temp), IsSuccess = true };
                }
                else
                {
                    weather = new WeatherModel { Error = "Didn't find the city you wrote" };
                }
            }
            catch(Exception ex)
            {
                weather = new WeatherModel { Error = $"Didn't find the city you wrote. Error = {ex.Message}" };
            }            

            return weather;
        }
    }
}
