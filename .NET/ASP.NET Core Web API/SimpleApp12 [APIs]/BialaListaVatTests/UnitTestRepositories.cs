using BialaListaVat.CustomExceptions;
using BialaListaVat.Repositories.Deserialization;
using BialaListaVat.Repositories.Url;
using BialaListaVat.ValueObjects.NipValue;
using BialaListaVat.ValueObjects.RegonValue;

namespace BialaListaVatTests
{
    public class UnitTestRepositories
    {
        [Fact]
        public void UrlRepository_GenerateUrlWithNip_Correct()
        {
            //Arrange
            var repository = new UrlRepository();
            var nip = new Nip("1234567890");
            var date = new DateOnly(2024, 08, 08);
            var expected = "https://wl-api.mf.gov.pl/api/search/nip/1234567890?date=2024-08-08";
            //Act
            var result = repository.GenerateUrlWithNip(nip, date);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void UrlRepository_GenerateUrlWithRegon_Correct()
        {
            //Arrange
            var repository = new UrlRepository();
            var regon = new Regon("123456789");
            var date = new DateOnly(2024, 08, 08);
            var expected = "https://wl-api.mf.gov.pl/api/search/regon/123456789?date=2024-08-08";
            //Act
            var result = repository.GenerateUrlWithRegon(regon, date);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void UrlRepository_IsValidHttpOrHttpsUrl_Correct_True()
        {
            //Arrange
            var repository = new UrlRepository();
            var url = "https://wl-api.mf.gov.pl/";
            //Act
            var result = repository.IsValidHttpOrHttpsUrl(url);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void UrlRepository_IsValidHttpOrHttpsUrl_Incorrect_False()
        {
            //Arrange
            var repository = new UrlRepository();
            var url = "ht://wl-api.mf.gov.pl/";
            //Act
            var result = repository.IsValidHttpOrHttpsUrl(url);

            //Assert
            Assert.False(result);
        }

        //====================================================================================================================================
        //====================================================================================================================================
        [Fact]
        public void DeserializationRepository_DeserializationSingleCompany_Correct()
        {
            //Arrange
            var repository = new DeserializationRepository();
            var body = "{\"result\":{\"subject\":{\"name\":\"G£ÓWNY URZ¥D STATYSTYCZNY\",\"nip\":\"5261040828\",\"statusVat\":\"Czynny\",\"regon\":\"000331501\",\"pesel\":null,\"krs\":null,\"residenceAddress\":null,\"workingAddress\":\"ALEJA NIEPODLAG£OŒCI 208, 00-925 WARSZAWA\",\"representatives\":[],\"authorizedClerks\":[],\"partners\":[],\"registrationLegalDate\":\"1996-01-29\",\"registrationDenialBasis\":null,\"registrationDenialDate\":null,\"restorationBasis\":null,\"restorationDate\":null,\"removalBasis\":null,\"removalDate\":null,\"accountNumbers\":[\"07101010100024791339300000\",\"42101010100024792231000000\",\"62101010100024791891100000\",\"92101010100024792230000000\",\"31101010100024791391200000\",\"79101010100024791398000000\",\"26101010100024791391300000\"],\"hasVirtualAccounts\":true},\"requestId\":\"LlXEq-909g193\",\"requestDateTime\":\"08-08-2024 18:32:27\"}}";
            //Act
            var result = repository.DeserializationSingleCompany(body);

            //Assert
            Assert.Equal("G£ÓWNY URZ¥D STATYSTYCZNY", result.Name);
        }

        [Fact]
        public void DeserializationRepository_DeserializationSingleCompany_BialaListaVatException()
        {
            //Arrange
            var repository = new DeserializationRepository();
            var body = "{\"result\":{\"requestId\":\"LlXEq-909g193\",\"requestDateTime\":\"08-08-2024 18:32:27\"}}";
            //Act
            //Assert
            Assert.Throws<BialaListaVatException>(() => repository.DeserializationSingleCompany(body));
        }

        [Fact]
        public void DeserializationRepository_DeserializationIncorrectResponse_Correct()
        {
            //Arrange
            var repository = new DeserializationRepository();
            var body = "{\"code\":\"WL-113\",\"message\":\"Pole 'NIP' ma nieprawid³ow¹ d³ugoœæ. Wymagane 10 znaków.\"}";
            //Act
            var result = repository.DeserializationIncorrectResponse(body);

            //Assert
            Assert.Equal("Pole 'NIP' ma nieprawid³ow¹ d³ugoœæ. Wymagane 10 znaków.", result.Message);
        }

        [Fact]
        public void DeserializationRepository_DeserializationIncorrectResponse_BialaListaVatException()
        {
            //Arrange
            var repository = new DeserializationRepository();
            var body = "null";
            //Act
            //Assert
            Assert.Throws<BialaListaVatException>(() => repository.DeserializationIncorrectResponse(body));
        }
        //====================================================================================================================================
        //====================================================================================================================================



    }
}