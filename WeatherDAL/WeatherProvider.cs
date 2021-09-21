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
        private readonly string _appid;
        private readonly string _url;

        public WeatherProvider(HttpClient client, ConfigOptions config)
        {
            _url = config.Url;
            _appid = config.AppId;            
            _client = client;
        }

        public async Task<WeatherResponse> GetWeatherAsync(string city)
        {
            var collection = new NameValueCollection();
            collection.Add("q", city);
            collection.Add("appid", _appid);
            var weatherUrl = Utils.UrlStringBuilder(_url, collection);

            var response = await _client.GetAsync(weatherUrl);
            var responseString = await response.Content.ReadAsStringAsync();
            var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseString);

            return weatherResponse;
        }
    }
}
