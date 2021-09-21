using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherDAL.Models;

namespace WeatherDAL
{
    public class WeatherProvider : IWeatherProvider
    {
        private readonly HttpClient _client;
        private readonly string appid;
        private readonly string url;

        public WeatherProvider(HttpClient client, ConfigOptions config)
        {
            url = config.Url;
            appid = config.AppId;            
            _client = client;
        }

        public async Task<WeatherResponse> GetWeatherAsync(string city)
        {
            var collection = new NameValueCollection();
            collection.Add("q", city);
            collection.Add("appid", appid);
            var weatherUrl = Utils.UrlStringBuilder(url, collection);

            var response = await _client.GetAsync(weatherUrl);
            var responseString = await response.Content.ReadAsStringAsync();
            var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseString);

            return weatherResponse;
        }
    }
}
