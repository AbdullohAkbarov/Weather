using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using WeatherBL;
using WeatherBL.Models;
using WeatherDAL;
using WeatherDAL.Models;

namespace GetWeatherTests
{
    [TestClass]
    public class WeatherTests
    {
        string url = "https://api.openweathermap.org/data/2.5/weather";
        string appid = "645958578ad07af2944914edc4469d13";
        string city = "London";

        [TestMethod]
        public void GetCurrentWeatherTest()
        {
            //arrange            
            WeatherService service = new WeatherService(url, appid);

            //act
            WeatherModel result = service.GetCurrentWeather(city).Result;

            //assert
            Assert.
        }

        [TestMethod]
        public async void GetWeatherAsyncTest()
        {
            //arrange
            WeatherProvider provider = new WeatherProvider(appid);
            WeatherResponse expected = new WeatherResponse();

            //act
            WeatherResponse result = await provider.GetWeatherAsync(url, city);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
