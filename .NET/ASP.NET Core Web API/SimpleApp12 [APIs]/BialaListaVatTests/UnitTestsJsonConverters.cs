using BialaListaVat.CustomJsonConverters;
using BialaListaVat.CustomJsonConverters.ConverterStatusVat;
using BialaListaVat.CustomJsonConverters.StatusVatConverter;
using System.Text.Json;

namespace BialaListaVatTests
{
    public class UnitTestsJsonConverters
    {
        [Fact]
        public void DateOnlyJsonConverter_ReturnsCorrectJson_DateOnly()
        {
            // Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new DateOnlyJsonConverter() }
            };
            DateOnly date = new DateOnly(2023, 8, 8);

            // Act
            string json = JsonSerializer.Serialize(date, options);

            // Assert
            Assert.Equal("\"2023-08-08\"", json);
        }

        [Fact]
        public void DateOnlyJsonConverter_ReturnsCorrectDateOnly_ValidJson()
        {
            // Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new DateOnlyJsonConverter() }
            };
            string json = "\"2023-08-08\"";

            // Act
            DateOnly date = JsonSerializer.Deserialize<DateOnly>(json, options);

            // Assert
            Assert.Equal(new DateOnly(2023, 8, 8), date);
        }

        [Fact]
        public void DateOnlyJsonConverter_ThrowsJsonException_InvalidJson()
        {
            // Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new DateOnlyJsonConverter() }
            };
            string json = "\"invalid-date\"";

            // Act & Assert
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<DateOnly>(json, options));
        }
        //================================================================================================================================
        //================================================================================================================================
        //================================================================================================================================
        [Fact]
        public void StatusVatJsonConverter_Correct_Czynny()
        {
            // Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new StatusVatJsonConverter() }
            };
            var status = StatusVat.Czynny;
            // Act
            string json = JsonSerializer.Serialize(status, options);

            // Assert
            Assert.Equal("\"Czynny\"", json);
        }

        [Fact]
        public void StatusVatJsonConverter_Correct_Zwolniony()
        {
            // Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new StatusVatJsonConverter() }
            };
            var status = StatusVat.Zwolniony;
            // Act
            string json = JsonSerializer.Serialize(status, options);

            // Assert
            Assert.Equal("\"Zwolniony\"", json);
        }

        [Fact]
        public void StatusVatJsonConverter_Correct_Niezarejestrowanyy()
        {
            // Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new StatusVatJsonConverter() }
            };
            var status = StatusVat.Niezarejestrowany;
            // Act
            string json = JsonSerializer.Serialize(status, options);

            // Assert
            Assert.Equal("\"Niezarejestrowany\"", json);
        }

        [Fact]
        public void StatusVatJsonConverter_Correct_Null()
        {
            // Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new StatusVatJsonConverter() }
            };
            var status = StatusVat.Null;
            // Act
            string json = JsonSerializer.Serialize(status, options);

            // Assert
            Assert.Equal("null", json);
        }

        [Fact]
        public void StatusVatJsonConverter_Correct_StatusVatCzynny()
        {
            // Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new StatusVatJsonConverter() }
            };
            var json = "\"Czynny\"";
            // Act
            var status = JsonSerializer.Deserialize<StatusVat>(json, options);

            // Assert
            Assert.Equal(StatusVat.Czynny, status);
        }

        [Fact]
        public void StatusVatJsonConverter_Correct_StatusVatZwolniony()
        {
            // Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new StatusVatJsonConverter() }
            };
            var json = "\"Zwolniony\"";
            // Act
            var status = JsonSerializer.Deserialize<StatusVat>(json, options);

            // Assert
            Assert.Equal(StatusVat.Zwolniony, status);
        }

        [Fact]
        public void StatusVatJsonConverter_Correct_StatusVatNiezarejestrowanyy()
        {
            // Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new StatusVatJsonConverter() }
            };
            var json = "\"Niezarejestrowany\"";
            // Act
            var status = JsonSerializer.Deserialize<StatusVat>(json, options);

            // Assert
            Assert.Equal(StatusVat.Niezarejestrowany, status);
        }

        [Fact]
        public void StatusVatJsonConverter_Correct_StatusVatNull()
        {
            // Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new StatusVatJsonConverter() }
            };
            var json = "\"\"";
            // Act
            var status = JsonSerializer.Deserialize<StatusVat>(json, options);

            // Assert
            Assert.Equal(StatusVat.Null, status);
        }

        [Fact]
        public void StatusVatJsonConverter_JsonException_ZZZ()
        {
            // Arrange
            var options = new JsonSerializerOptions
            {
                Converters = { new StatusVatJsonConverter() }
            };
            var json = "\"ZZZ\"";
            // Act & Assert
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<StatusVat>(json, options));
        }
    }
}
