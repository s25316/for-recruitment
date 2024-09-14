using Regon.ValueObjectsAndTheirExceptions.CustomDateOnlyXmlElement;
using Regon.ValueObjectsAndTheirExceptions.NipValue;
using Regon.ValueObjectsAndTheirExceptions.RegonValue;
using Regon.ValueObjectsAndTheirExceptions.SessionIdValue;
using Regon.ValueObjectsAndTheirExceptions.SilosIdValue;
using Regon.ValueObjectsAndTheirExceptions.TypJednostkiValue;
using Regon.ValueObjectsAndTheirExceptions.UserKeyValue;
using System.Xml;
using System.Xml.Serialization;
using Xunit.Abstractions;

namespace RegonTests
{
    public class UnitTestsValueObjects
    {
        private readonly ITestOutputHelper _output;

        public UnitTestsValueObjects(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("zzz")]
        [InlineData("1234")]
        public void UserKey_Correct_Theory(string userKey)
        {
            //Arrange
            //Act
            var result = new UserKey(userKey);
            //Assert
            Assert.Equal(userKey, result.Key);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void UserKey_UserKeyException_Empty(string userKey)
        {
            //Arrange
            //Act
            //Assert
            var ex = Assert.Throws<UserKeyException>(() => new UserKey(userKey));
            _output.WriteLine(ex.Message);
        }

        //=========================================================================================================================================
        //=========================================================================================================================================
        [Fact]
        public void TypJednostki_Correct_P()
        {
            //Arrange
            //Act
            var result = CreateClassAndReadXml<TypJednostki>("P");
            //Assert
            Assert.Equal("jednostka prawna", result.Description);
        }

        [Fact]
        public void TypJednostki_Correct_F()
        {
            //Arrange
            //Act
            var result = CreateClassAndReadXml<TypJednostki>("F");
            //Assert
            Assert.Equal("jednostka fizyczna (os. fizyczna prowadząca działalność gospodarczą)", result.Description);
        }

        [Fact]
        public void TypJednostki_Correct_LP()
        {
            //Arrange
            //Act
            var result = CreateClassAndReadXml<TypJednostki>("lp");
            //Assert
            Assert.Equal("jednostka lokalna jednostki prawnej", result.Description);
        }

        [Fact]
        public void TypJednostki_Correct_LF()
        {
            //Arrange
            //Act
            var result = CreateClassAndReadXml<TypJednostki>("lf");
            //Assert
            Assert.Equal("jednostka lokalna jednostki fizycznej", result.Description);
        }

        [Theory]
        [InlineData("Z")]
        [InlineData("XzX")]
        public void TypJednostki_TypJednostkiException_Theory(string data)
        {
            //Arrange
            //Act
            //Assert
            var ex = Assert.Throws<TypJednostkiException>(() => CreateClassAndReadXml<TypJednostki>(data));
            _output.WriteLine(ex.Message);
        }

        //=========================================================================================================================================
        //=========================================================================================================================================
        [Fact]
        public void SilosId_Correct_1()
        {
            //Arrange
            //Act
            var result = CreateClassAndReadXml<SilosId>("1");
            //Assert
            Assert.Equal("Miejsce prowadzenia działalności zarejestrowanej w CEIDG", result.Description);
        }


        [Fact]
        public void SilosId_Correct_2()
        {
            //Arrange
            //Act
            var result = CreateClassAndReadXml<SilosId>("2");
            //Assert
            Assert.Equal("Miejsce prowadzenia działalności rolniczej", result.Description);
        }

        [Fact]
        public void SilosId_Correct_3()
        {
            //Arrange
            //Act
            var result = CreateClassAndReadXml<SilosId>("3");
            //Assert
            Assert.Equal("Miejsce prowadzenia działalności pozostałej", result.Description);
        }

        [Fact]
        public void SilosId_Correct_4()
        {
            //Arrange
            //Act
            var result = CreateClassAndReadXml<SilosId>("4");
            //Assert
            Assert.Equal("Miejsce prowadzenia działalności zlikwidowanej w starym systemie KRUPGN", result.Description);
        }

        [Fact]
        public void SilosId_Correct_6()
        {
            //Arrange
            //Act
            var result = CreateClassAndReadXml<SilosId>("6");
            //Assert
            Assert.Equal("Miejsce prowadzenia działalności jednostki prawnej", result.Description);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(787)]
        public void SilosId_SilosIdException_Theory(int code)
        {
            // Arrange
            //Act
            var result = CreateClassAndReadXml<SilosId>("6");
            //Assert
            var ex = Assert.Throws<SilosIdException>(() => CreateClassAndReadXml<SilosId>(code.ToString()));
            _output.WriteLine(ex.Message);
        }
        //=========================================================================================================================================
        //=========================================================================================================================================

        [Theory]
        [InlineData("Xt9BbHBhLemhjlP0qtZg")]
        [InlineData("5KeNAVhkF2I7mkZ2b8GL")]
        [InlineData("P1H6emKqpLC4QcldZEK9")]
        public void Sid_Correct_Theory(string sid)
        {
            //Arrange 
            //Act
            var result = new SesionId(sid);
            //Assert
            Assert.Equal(sid, result.Id);
        }
        //=========================================================================================================================================
        //=========================================================================================================================================
        [Theory]
        [InlineData("6282 767 94")]
        [InlineData("381552628")]
        [InlineData("839293628")]
        [InlineData("32200211456555")]
        [InlineData("988-45-169-113-285")]
        [InlineData(" 72920799344497 ")]
        public void Regon_Correct_Theory(string regon)
        {
            //Arrange
            //Act
            var result = CreateClassAndReadXml<Regon.ValueObjectsAndTheirExceptions.RegonValue.Regon>(regon);

            regon = regon
                .Replace("-", "")
                .Replace(" ", "")
                .Trim();
            //Assert
            Assert.Equal(regon, result.Number);
        }
        [Theory]
        [InlineData("")]
        [InlineData("3815526")]
        [InlineData("8392936")]
        [InlineData(" 3220021145655 ")]
        [InlineData("988-45-169-113-2854")]
        [InlineData("72920799344497xx")]
        public void Regon_RegonException_Theory(string regon)
        {
            //Arrange
            //Act
            //Assert
            var ex = Assert.Throws<RegonException>(() => CreateClassAndReadXml<Regon.ValueObjectsAndTheirExceptions.RegonValue.Regon>(regon));
            _output.WriteLine(ex.Message);
        }
        //=========================================================================================================================================
        //=========================================================================================================================================
        [Theory]
        [InlineData("2458571425")]
        [InlineData(" 3815526286 ")]
        [InlineData("83-9-293-62-83")]
        public void Nip_Correct_Theory(string nip)
        {
            //Arrange
            //Act
            var result = new Regon.ValueObjectsAndTheirExceptions.NipValue.Nip(nip);

            nip = nip
                .Replace("-", "")
                .Replace(" ", "")
                .Trim();
            //Assert
            Assert.Equal(nip, result.Number);
        }
        [Theory]
        [InlineData("")]
        [InlineData("3815526")]
        [InlineData("8392936")]
        [InlineData(" 3220021145655 ")]
        [InlineData("988-45-169-113-2854")]
        [InlineData("72920799344497xx")]
        public void Nip_NipException_Theory(string nip)
        {
            //Arrange
            //Act
            //Assert
            var ex = Assert.Throws<NipException>(() => new Regon.ValueObjectsAndTheirExceptions.NipValue.Nip(nip));
            _output.WriteLine(ex.Message);
        }
        //=========================================================================================================================================
        //=========================================================================================================================================
        [Theory]
        [InlineData("2024-07-12")]
        [InlineData("2024-01-12")]
        [InlineData("2024-08-07")]
        [InlineData("")]
        [InlineData(" ")]
        public void CustomDateOnly_Correct_Theory(string data)
        {
            //Arrange
            //Act
            var result = CreateClassAndReadXml<CustomDateOnly>(data);
            //Assert
            if (result.DateOnly.HasValue)
            {
                Assert.Equal(data, result.DateOnly.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                data = data.Trim();
                Assert.True(string.IsNullOrEmpty(data));
            }
        }

        [Theory]
        [InlineData("2024-08-072")]
        [InlineData("as")]
        [InlineData("12 ")]
        public void CustomDateOnly_CustomDateOnlyException_Theory(string data)
        {
            //Arrange
            //Act
            //Assert
            var ex = Assert.Throws<CustomDateOnlyException>(() => CreateClassAndReadXml<CustomDateOnly>(data));
            _output.WriteLine(ex.Message);
        }
        //=========================================================================================================================================
        //=========================================================================================================================================

        //=========================================================================================================================================
        //=========================================================================================================================================

        //Others ...

        //====================================================================================================================================================================================
        //Private Methods
        //====================================================================================================================================================================================
        //====================================================================================================================================================================================
        private T CreateClassAndReadXml<T>(string value) where T : class, IXmlSerializable, new()
        {
            string xmlContent = $"<Typ>{value}</Typ>";

            using (StringReader stringReader = new StringReader(xmlContent))
            using (XmlReader xmlReader = XmlReader.Create(stringReader))
            {
                var typJednostki = new T();
                xmlReader.MoveToContent();
                typJednostki.ReadXml(xmlReader);
                return typJednostki;
            }
        }

        private static string GetDataFromClassByWriterXml<T>(T obj) where T : class, IXmlSerializable
        {
            var elementName = "Typ";
            var settings = new XmlWriterSettings
            {
                ConformanceLevel = ConformanceLevel.Fragment, // Ustawienie ConformanceLevel na Fragment
                OmitXmlDeclaration = true, // Opcjonalne: Pomija deklarację XML
                Indent = true // Opcjonalne: Formatowanie wynikowego XML
            };
            using (StringWriter stringWriter = new StringWriter())
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter))
            {
                // Otwórz element o nazwie elementName
                xmlWriter.WriteStartElement(elementName);

                // Zapisz zawartość przy użyciu obj.WriteXml
                obj.WriteXml(xmlWriter);

                // Zamknij element
                xmlWriter.WriteEndElement();

                xmlWriter.Flush();  // Upewnij się, że cały bufor został zapisany
                return stringWriter.ToString();
            }
        }

    }
}
