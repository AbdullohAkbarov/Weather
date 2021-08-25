using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using WeatherBL.Models;
using WeatherDAL;

namespace WeatherBL
{
    public class WeatherService
    {
        private HttpClient client;
        private string url;
        private string appid;
        Weather weather;

        public WeatherService(string url, string appid)
        {
            this.url = url;
            this.appid = appid;
        }

        public Weather GetCurrentWeather(string city)
        {
            WeatherProvider provider = new WeatherProvider(client);

            NameValueCollection collection = new NameValueCollection();
            collection.Add("q", city);
            collection.Add("appid", appid);
            string weatherUrl = Utils.UrlStringBuilder(url, collection);

            var response = provider.CallOpenWeather(weatherUrl);
            if(response != null)
            {
                weather = new Weather(city, response.GetTemp(), true);
            }
            else
            {
                weather = new Weather(false, "Didn't find the city you wrote");
            }

            return weather;
        }
    }
}
