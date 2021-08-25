using System;
using WeatherBL;
using System.Configuration;
using System.Net.Http;

namespace Weather
{
    public class Program
    {
        static string url = ConfigurationManager.AppSettings["weatherUrl"];
        static string appid = ConfigurationManager.AppSettings["appid"];
        //HttpClient client;

        public static void Main(string[] args)
        {
            WeatherService service = new WeatherService(url, appid);

            Console.Write("Write to city which you want to know the wheather ");

            string city = Console.ReadLine();

            string response = service.GetCurrentWeather(city);

            Console.WriteLine(response);

            Console.ReadLine();
        }
    }
}
