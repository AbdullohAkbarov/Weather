using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherBL;
using System.Configuration;

namespace Weather
{
    public class Program
    {
        static string url = ConfigurationManager.AppSettings["weatherUrl"];
        static string appid = ConfigurationManager.AppSettings["appid"];

        public static void Main(string[] args)
        {
            WeatherService service = new WeatherService();

            Console.Write("Write to city which you want to know the wheather ");

            string city = Console.ReadLine();

            string response = service.CurrentWeather(url, appid, city);

            Console.WriteLine(response);
        }
    }
}
