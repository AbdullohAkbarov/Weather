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
        private HttpClient client;
        private string appid;
        private WeatherResponse weatherResponse;

        public WeatherProvider(string appid)
        {
            this.appid = appid;
            client = new HttpClient();
        }

        public async Task<WeatherResponse> GetWeatherAsync(string url, string city)
        {
            var collection = new NameValueCollection();
            collection.Add("q", city);
            collection.Add("appid", appid);
            string weatherUrl = Utils.UrlStringBuilder(url, collection);

            var response = await client.GetAsync(weatherUrl);
            var responseString = await response.Content.ReadAsStringAsync();
            weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseString);

            return weatherResponse;
        }
    }
}
