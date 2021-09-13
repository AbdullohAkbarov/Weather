using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherBL.Validators;

namespace WeatherTests.UnitTests
{
    [TestFixture]
    public class CityValidatorTests
    {
        private CityValidator cityValidator;
        private string city;
        private string nullCity;

        public CityValidatorTests()
        {
            cityValidator = new CityValidator();
            city = "London";
            nullCity = null;
        }

        [Test]
        public void Validate_CityNameIsNotNull_ReturnsTrue()
        {
            //Arrange

            //Act
            var result = cityValidator.Validate(city);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Validate_CityNameIsNull_ReturnsFalse()
        {
            //Arrange

            //Act
            var result = cityValidator.Validate(nullCity);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
