using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using WeatherBL.Models.WeatherBL;

namespace WeatherBL
{
    public static class Utils
    {
        public static string UrlStringBuilder(string url, NameValueCollection collection)
        {
            string[] array = (
                from key in collection.AllKeys
                from value in collection.GetValues(key)
                select string.Format("{0}={1}",
                    HttpUtility.UrlEncode(key),
                    HttpUtility.UrlEncode(value))
                ).ToArray();

            return string.Join("?", url, string.Join("&", array));
        }

        public static WeatherResponse Converter(HttpResponseMessage message)
        {
            try
            {
                var responseString = message.Content.ReadAsStringAsync().Result;

                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseString);

                return weatherResponse;
            }
            catch(Exception ex)
            {
                return new WeatherResponse { };
            }            
        }
    }
}
