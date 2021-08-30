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
        public HttpClient Client { get; set; }
        public string Appid { get; set; }
        public string Url { get; set; }

        public WeatherProvider(HttpClient client, string url, string appid)
        {
            Appid = appid;
            Url = url;
            Client = client;
        }

        public async Task<WeatherResponse> GetWeatherAsync(string city)
        {
            var collection = new NameValueCollection();
            collection.Add("q", city);
            collection.Add("appid", Appid);
            string weatherUrl = Utils.UrlStringBuilder(Url, collection);

            var response = await Client.GetAsync(weatherUrl);
            var responseString = await response.Content.ReadAsStringAsync();
            var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseString);

            return weatherResponse;
        }
    }
}
