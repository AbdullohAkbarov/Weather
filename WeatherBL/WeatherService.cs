using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using WeatherDAL;

namespace WeatherBL
{
    public class WeatherService : IWeather
    {
        HttpClient client;

        public double CurrentWeather(string weatherUrl, string appid, string city)
        {
            NameValueCollection collection = new NameValueCollection();
            collection.Add("q", city);
            collection.Add("appid", appid);
            string url = Utils.UrlStringBuilder(weatherUrl, collection);

            var responseWeather = client.PostAsync(url, null).Result;

            var weatherResponse = Utils.Converter(responseWeather);

            return weatherResponse.GetTemp();
        }
    }
}
