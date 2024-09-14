using Regon.Repositories.SoapEnvelopes;
using Regon.ValueObjectsAndTheirExceptions.NipValue;
using Regon.ValueObjectsAndTheirExceptions.SessionIdValue;
using Regon.ValueObjectsAndTheirExceptions.UserKeyValue;
using System.Xml;

namespace RegonTests
{
    public class UnitTestsEnvelopesRepository
    {
        [Fact]
        public void EnvelopesRepository_GetSoapEndpoint_False_ProductionUrl()
        {
            //Arrange
            var envelopes = new EnvelopesRepository();
            //Act
            var url = envelopes.GetSoapEndpoint();
            //Assert
            Assert.Equal("https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc", url);
        }

        [Fact]
        public void EnvelopesRepository_GetSoapEndpoint_False_TestUrl()
        {
            //Arrange
            var envelopes = new EnvelopesRepository();
            //Act
            var url = envelopes.GetSoapEndpoint(false);
            //Assert
            Assert.Equal("https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc", url);
        }
        //========================================================================================================================================
        //========================================================================================================================================
        //========================================================================================================================================
        [Fact]
        public void EnvelopesRepository_ZalogujEnvelope()
        {
            //Arrange
            var xmlExpected = "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:ns=\"http://CIS/BIR/PUBL/2014/07\"> \r\n<soap:Header xmlns:wsa=\"http://www.w3.org/2005/08/addressing\"> \r\n<wsa:Action>http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/Zaloguj</wsa:Action> \r\n<wsa:To>https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc</wsa:To> \r\n</soap:Header> \r\n<soap:Body> \r\n<ns:Zaloguj>  \r\n<ns:pKluczUzytkownika>pmmhfocfcdbehnthnfkx</ns:pKluczUzytkownika> \r\n</ns:Zaloguj> \r\n</soap:Body> \r\n</soap:Envelope>";
            var expected = new XmlDocument();
            expected.LoadXml(xmlExpected);

            var envelopes = new EnvelopesRepository();
            var key = new UserKey("pmmhfocfcdbehnthnfkx");

            //Act
            var testValue = envelopes.ZalogujEnvelope(key, false);
            var result = new XmlDocument();
            result.LoadXml(testValue);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EnvelopesRepository_DanePobierzPelnyRaportEnvelope()
        {
            //Arrange
            var xmlExpected = "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:ns=\"http://CIS/BIR/PUBL/2014/07\"> \r\n<soap:Header xmlns:wsa=\"http://www.w3.org/2005/08/addressing\"> \r\n<wsa:Action>http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DanePobierzPelnyRaport</wsa:Action> \r\n<wsa:To>https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc</wsa:To> \r\n</soap:Header> \r\n<soap:Body> \r\n<ns:DanePobierzPelnyRaport>                  \r\n<ns:pRegon>00033150100000</ns:pRegon> \r\n<ns:pNazwaRaportu>PublDaneRaportPrawna</ns:pNazwaRaportu>          \r\n</ns:DanePobierzPelnyRaport> \r\n</soap:Body> \r\n</soap:Envelope> ";
            var expected = new XmlDocument();
            expected.LoadXml(xmlExpected);

            var envelopes = new EnvelopesRepository();
            var regon = new Regon.ValueObjectsAndTheirExceptions.RegonValue.Regon
            {
                Number = "00033150100000",
            };
            var raport = "PublDaneRaportPrawna";

            //Act
            var resultXml = envelopes.DanePobierzPelnyRaportEnvelope(regon, raport, false);
            var result = new XmlDocument();
            result.LoadXml(resultXml);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EnvelopesRepository_WylogujEnvelope()
        {
            //Arrange
            var expectedXml = "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:ns=\"http://CIS/BIR/PUBL/2014/07\">\r\n<soap:Header xmlns:wsa=\"http://www.w3.org/2005/08/addressing\">\r\n<wsa:To>https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc</wsa:To>\r\n<wsa:Action>http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/Wyloguj</wsa:Action>\r\n</soap:Header>\r\n   <soap:Body>\r\n      <ns:Wyloguj>\r\n         <ns:pIdentyfikatorSesji>k4r3h2y8r6w5h4d4n7d4</ns:pIdentyfikatorSesji>\r\n      </ns:Wyloguj>\r\n   </soap:Body>\r\n</soap:Envelope>";
            var expected = new XmlDocument();
            expected.LoadXml(expectedXml);

            var envelopes = new EnvelopesRepository();
            var sessionId = new SesionId("k4r3h2y8r6w5h4d4n7d4");

            //Act
            var resultXml = envelopes.WylogujEnvelope(sessionId, false);
            var result = new XmlDocument();
            result.LoadXml(resultXml);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EnvelopesRepository_DaneSzukajByNipEnvelope()
        {
            //Arrange
            var expectedXml = "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:ns=\"http://CIS/BIR/PUBL/2014/07\" xmlns:dat=\"http://CIS/BIR/PUBL/2014/07/DataContract\">\r\n   <soap:Header xmlns:wsa=\"http://www.w3.org/2005/08/addressing\">\r\n<wsa:To>https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc</wsa:To>\r\n<wsa:Action>http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukaj</wsa:Action>\r\n</soap:Header>\r\n   <soap:Body>\r\n      <ns:DaneSzukaj>\r\n         <ns:pParametryWyszukiwania>\r\n            <dat:Nip>1111111111</dat:Nip>\r\n         </ns:pParametryWyszukiwania>\r\n      </ns:DaneSzukaj>\r\n   </soap:Body>\r\n</soap:Envelope>";
            var expected = new XmlDocument();
            expected.LoadXml(expectedXml);

            var envelopes = new EnvelopesRepository();
            var nip = new Nip("1111111111");

            //Act
            var resultXml = envelopes.DaneSzukajByNipEnvelope(nip, false);
            var result = new XmlDocument();
            result.LoadXml(resultXml);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EnvelopesRepository_DaneSzukajByRegonEnvelope()
        {
            //Arrange
            var expectedXml = "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:ns=\"http://CIS/BIR/PUBL/2014/07\" xmlns:dat=\"http://CIS/BIR/PUBL/2014/07/DataContract\">\r\n   <soap:Header xmlns:wsa=\"http://www.w3.org/2005/08/addressing\">\r\n<wsa:To>https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc</wsa:To>\r\n<wsa:Action>http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukaj</wsa:Action>\r\n</soap:Header>\r\n   <soap:Body>\r\n      <ns:DaneSzukaj>\r\n         <ns:pParametryWyszukiwania>\r\n            <dat:Regon>142396858</dat:Regon>\r\n         </ns:pParametryWyszukiwania>\r\n      </ns:DaneSzukaj>\r\n   </soap:Body>\r\n</soap:Envelope>";
            var expected = new XmlDocument();
            expected.LoadXml(expectedXml);

            var envelopes = new EnvelopesRepository();
            var regon = new Regon.ValueObjectsAndTheirExceptions.RegonValue.Regon
            {
                Number = "142396858"
            };

            //Act
            var resultXml = envelopes.DaneSzukajByRegonEnvelope(regon, false);
            var result = new XmlDocument();
            result.LoadXml(resultXml);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}