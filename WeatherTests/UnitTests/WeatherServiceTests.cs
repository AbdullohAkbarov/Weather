using Moq;
using NUnit.Framework;
using WeatherBL;
using WeatherBL.Models;
using WeatherDAL;
using WeatherDAL.Models;

namespace WeatherTests.UnitTests
{
    public class WeatherServiceTests
    {
        [Test]
        public async void GetCurrentWeatherAsync_CityEqualsCity_Boolean()
        {
            //Arrange
            WeatherService service;
            var city = "Tashkent";
            var mock = new Mock<IWeatherProvider>();
            mock.Setup(m => m.GetWeatherAsync(city)).ReturnsAsync(new WeatherResponse());
            service = new WeatherService(mock.Object);

            //Act
            var result = await service.GetCurrentWeatherAsync(city);


            //Assert
            Assert.Equals(result.City, city);
        }
    }
}
