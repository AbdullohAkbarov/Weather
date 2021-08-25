using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using WeatherBL.Models.WeatherBL;
using WeatherDAL.Models;

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
    }
}
