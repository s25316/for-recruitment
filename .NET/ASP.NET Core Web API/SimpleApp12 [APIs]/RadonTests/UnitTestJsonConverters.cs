using Radon.CustomJsonConverters;
using System.Text.Json;
using Xunit.Abstractions;

namespace RadonTests
{
    public class UnitTestJsonConverters
    {
        private readonly ITestOutputHelper _output;

        public UnitTestJsonConverters(ITestOutputHelper output)
        {
            _output = output;
        }


        [Fact]
        public void DateOnlyJsonConverter_Serialize_NotEmptyValue_Correct()
        {
            //Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new DateOnlyJsonConverter() }
            };
            var date = new DateOnly(2024, 08, 08);
            //Act
            var json = JsonSerializer.Serialize(date, options);
            //Assert
            Assert.Equal("\"2024-08-08\"", json);
        }

        [Fact]
        public void DateOnlyJsonConverter_Serialize_EmptyValue_Correct()
        {
            //Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new DateOnlyJsonConverter() }
            };
            DateOnly? date = null;
            //Act
            var json = JsonSerializer.Serialize(date, options);
            //Assert
            Assert.Equal("null", json);
        }

        [Fact]
        public void DateOnlyJsonConverter_Deserialize__FromOnly_Correct()
        {
            //Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new DateOnlyJsonConverter() }
            };
            var json = "\"2024-08-08\"";
            var date = new DateOnly(2024, 08, 08);

            //Act
            var result = JsonSerializer.Deserialize<DateOnly>(json, options);
            //Assert
            Assert.Equal(date.Day, result.Day);
        }

        [Fact]
        public void DateOnlyJsonConverter_Deserialize_Incorrect()
        {
            //Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new DateOnlyJsonConverter() }
            };
            var json = "\"\"";

            //Act
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<DateOnly>(json, options));
        }
        //=====================================================================================================================================
        //=====================================================================================================================================
        [Fact]
        public void PolishBoolJsonConverter_Deserialize_Correct_True()
        {
            //Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new PolishBoolJsonConverter() }
            };
            var json = "\"tak\"";

            //Act
            var result = JsonSerializer.Deserialize<bool?>(json, options);
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void PolishBoolJsonConverter_Deserialize_Correct_False()
        {
            //Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new PolishBoolJsonConverter() }
            };
            var json = "\"nie\"";

            //Act
            var result = JsonSerializer.Deserialize<bool?>(json, options);
            //Assert
            Assert.False(result);
        }
        [Fact]
        public void PolishBoolJsonConverter_Deserialize_Correct_Null()
        {
            //Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new PolishBoolJsonConverter() }
            };
            var json = "\"\"";

            //Act
            var result = JsonSerializer.Deserialize<bool?>(json, options);
            //Assert
            Assert.Null(result);
        }
        [Fact]
        public void PolishBoolJsonConverter_Deserialize_JsonException()
        {
            //Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new PolishBoolJsonConverter() }
            }; ;
            var json = "\"zz\"";

            //Act
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<bool?>(json, options));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [InlineData(null)]
        public void PolishBoolJsonConverter_Serialize_Correct(bool? value)
        {
            //Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new PolishBoolJsonConverter() }
            };
            var expected = (value == null || value.ToString() == null) ? "null" : $"\"{value.ToString()}\"";
            //Act
            var json = JsonSerializer.Serialize(value, options);
            //Assert
            Assert.Equal(expected, json);
        }
        //=====================================================================================================================================
        //=====================================================================================================================================
        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        public void StringIntJsonConverter_Deserialize_Correct_Theory(int number)
        {
            //Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new StringIntJsonConverter() }
            };
            var json = $"\"{number.ToString()}\"";

            //Act
            var result = JsonSerializer.Deserialize<int?>(json, options);
            //Assert
            Assert.Equal(number, result);
        }
        [Fact]
        public void StringIntJsonConverter_Deserialize_Correct_EmptyString()
        {
            //Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new StringIntJsonConverter() }
            };
            var json = $"\"\"";

            //Act
            var result = JsonSerializer.Deserialize<int?>(json, options);
            //Assert
            Assert.Null(result);
        }
        [Fact]
        public void StringIntJsonConverter_Deserialize_JsonException()
        {
            //Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new StringIntJsonConverter() }
            }; ;
            var json = "\"zz\"";

            //Act
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<int?>(json, options));
        }
        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        public void StringIntJsonConverter_Serialize_Correct(int? value)
        {
            //Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new StringIntJsonConverter() }
            };
            //Act
            var json = JsonSerializer.Serialize(value, options);
            //Assert
            Assert.Equal($"\"{value.ToString()}\"", json);
        }
        //=====================================================================================================================================
        //=====================================================================================================================================
    }
}