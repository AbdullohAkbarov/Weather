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

        public static void Main(string[] args)
        {
            WeatherService service = new WeatherService(url, appid);

            Console.Write("Write to city which you want to know the wheather = ");

            var city = Console.ReadLine();

            var response = service.GetCurrentWeather(city).Result;
            if(response.IsSuccess is true)
            {
                Console.WriteLine($"The weather in {response.City} City right now is {response.Temperature}");
            }
            else
            {
                Console.WriteLine(response.Error);
            }            

            Console.ReadLine();
        }
    }
}
