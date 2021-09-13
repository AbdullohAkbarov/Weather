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
        private readonly CityValidator _cityValidator;
        private string city;
        private string nullCity;

        public CityValidatorTests()
        {
            _cityValidator = new CityValidator();
        }

        [Test]
        public void Validate_CityNameIsNotNull_ReturnsIsNotNull()
        {
            //Arrange
            city = "London";

            //Act
            var result = _cityValidator.Validate(city);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Validate_CityNameIsNull_ReturnsFalse()
        {
            //Arrange
            nullCity = null;

            //Act
            var result = _cityValidator.Validate(nullCity);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
