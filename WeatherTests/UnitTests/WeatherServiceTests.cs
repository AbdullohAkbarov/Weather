using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using WeatherBL;
using WeatherBL.Models;
using WeatherBL.Validators;
using WeatherDAL;
using WeatherDAL.Models;

namespace WeatherTests.UnitTests
{
    [TestFixture]
    public class WeatherServiceTests
    {
        [Test]
        public async Task GetCurrentWeatherAsync_CityEqualsCity_Boolean()
        {
            //Arrange
            WeatherService service;
            var city = "Tashkent";
            var mock = new Mock<IWeatherProvider>();
            mock.Setup(m => m.GetWeatherAsync(city)).ReturnsAsync(new WeatherResponse());
            service = new WeatherService(mock.Object, new CityValidator());

            //Act
            var result = await service.GetCurrentWeatherAsync(city);

            //Assert
            Assert.AreEqual(result.City, city);
        }
    }
}
