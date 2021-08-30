using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WeatherDAL;

namespace Weather.Tests.WeatherDAL
{
    [TestClass]
    public class WeatherProviderTests
    {

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
