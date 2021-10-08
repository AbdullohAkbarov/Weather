using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherDAL.Entities;
using WeatherDAL.Models;
using WeatherDAL.Repositories;

namespace WeatherDAL
{
    public class WeatherProvider : IWeatherProvider
    {
        private readonly HttpClient _client;
        private readonly string _appid;
        private readonly string _url;
        private readonly WeatherRepository _repo;

        public WeatherProvider(HttpClient client, ConfigOptions config)
        {
            _url = config.Url;
            _appid = config.AppId;            
            _client = client;
            _repo = new WeatherRepository();
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

        public async Task InsertWeatherAsync(string city, double temp)
        {
            await _repo.Insert(new Weather() { City = city, Temperature = temp, Date = DateTime.Now });
        }

        public async Task<List<Weather>> GetWeatherHistoryAsync(string city)
        {
            return await _repo.GetByCityAll(city);
        }
    }
}
