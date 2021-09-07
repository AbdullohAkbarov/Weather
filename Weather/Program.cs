using System;
using WeatherBL;
using System.Configuration;
using System.Net.Http;
using WeatherDAL;

namespace Weather
{
    public class Program
    {
        static string url = ConfigurationManager.AppSettings["url"];
        static string appid = ConfigurationManager.AppSettings["appid"];

        public static void Main(string[] args)
        {
            var service = new WeatherService(new WeatherProvider(new HttpClient(), url, appid));

            Console.Write("Write to city which you want to know the wheather = ");

            var city = Console.ReadLine();

            var response = service.GetCurrentWeatherAsync(city).GetAwaiter().GetResult();
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
