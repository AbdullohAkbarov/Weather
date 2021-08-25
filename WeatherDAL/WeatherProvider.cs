using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WeatherDAL.Models;

namespace WeatherDAL
{
    public class WeatherProvider : IWeatherProvider
    {
        private HttpClient client;

        public WeatherProvider()
        {
            client = new HttpClient();
        }
        public WeatherProvider(HttpClient client)
        {
            this.client = client;
        }

        public WeatherResponse CallOpenWeather(string url)
        {
            WeatherResponse weatherResponse;
            try
            {
                var response = client.GetAsync(url).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseString);

                return weatherResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
