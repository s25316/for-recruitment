using Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses;
using Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CustomResponse.Aggregates;
using Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CustomResponse.Entities.Adress;
using Regon.Repositories.EnvelopesDeserialization;
using Regon.ValueObjectsAndTheirExceptions.NazwaRaportuValue;
using Regon.ValueObjectsAndTheirExceptions.SilosIdValue;
using Regon.ValueObjectsAndTheirExceptions.TypJednostkiValue;
using System.Xml;
using System.Xml.Serialization;

namespace RegonTests
{
    public class UnitTestsCompany
    {
        [Fact]
        public void Company_DaneJednostkiPrawnej_Correct()
        {
            //Arrange
            var dane = "<dane>\r\n    <praw_regon14>00033150100000</praw_regon14>\r\n    <praw_nip>5261040828</praw_nip>\r\n    <praw_nazwa>GŁÓWNY URZĄD STATYSTYCZNY</praw_nazwa>\r\n    <praw_nazwaSkrocona>GUS</praw_nazwaSkrocona>\r\n    <praw_numerWrejestrzeEwidencji />\r\n\t<praw_dataWpisuDoRejestruEwidencji>1975-12-15</praw_dataWpisuDoRejestruEwidencji>\r\n    <praw_dataPowstania>1975-12-15</praw_dataPowstania>\r\n    <praw_dataRozpoczeciaDzialalnosci>1975-12-15</praw_dataRozpoczeciaDzialalnosci>\r\n    <praw_dataWpisuDoREGON />\r\n    <praw_dataZawieszeniaDzialalnosci />\r\n    <praw_dataWznowieniaDzialalnosci />\r\n    <praw_dataZaistnieniaZmiany>2009-02-20</praw_dataZaistnieniaZmiany>\r\n    <praw_dataZakonczeniaDzialalnosci />\r\n    <praw_dataSkresleniazRegon />\r\n    <praw_adSiedzKraj_Symbol>PL</praw_adSiedzKraj_Symbol>\r\n    <praw_adSiedzWojewodztwo_Symbol>14</praw_adSiedzWojewodztwo_Symbol>\r\n    <praw_adSiedzPowiat_Symbol>65</praw_adSiedzPowiat_Symbol>\r\n    <praw_adSiedzGmina_Symbol>108</praw_adSiedzGmina_Symbol>\r\n    <praw_adSiedzKodPocztowy>00925</praw_adSiedzKodPocztowy>\r\n    <praw_adSiedzMiejscowoscPoczty_Symbol>0919810</praw_adSiedzMiejscowoscPoczty_Symbol>\r\n    <praw_adSiedzMiejscowosc_Symbol>0919810</praw_adSiedzMiejscowosc_Symbol>\r\n    <praw_adSiedzUlica_Symbol>14199</praw_adSiedzUlica_Symbol>\r\n    <praw_adSiedzNumerNieruchomosci>208</praw_adSiedzNumerNieruchomosci>\r\n    <praw_adSiedzNumerLokalu />\r\n    <praw_adSiedzNietypoweMiejsceLokalizacji />\r\n    <praw_numerTelefonu>6083000</praw_numerTelefonu>\r\n    <praw_numerWewnetrznyTelefonu />\r\n    <praw_numerFaksu>0226083863</praw_numerFaksu>\r\n    <praw_adresEmail>dgsek@stat.gov.pl</praw_adresEmail>\r\n    <praw_adresStronyinternetowej>www.stat.gov.pl</praw_adresStronyinternetowej>\r\n    <praw_adresEmail2 />\r\n    <praw_adSiedzKraj_Nazwa>POLSKA</praw_adSiedzKraj_Nazwa>\r\n    <praw_adSiedzWojewodztwo_Nazwa>MAZOWIECKIE</praw_adSiedzWojewodztwo_Nazwa>\r\n    <praw_adSiedzPowiat_Nazwa>m. st. Warszawa</praw_adSiedzPowiat_Nazwa>\r\n    <praw_adSiedzGmina_Nazwa>Śródmieście</praw_adSiedzGmina_Nazwa>\r\n    <praw_adSiedzMiejscowosc_Nazwa>Warszawa</praw_adSiedzMiejscowosc_Nazwa>\r\n    <praw_adSiedzMiejscowoscPoczty_Nazwa>Warszawa</praw_adSiedzMiejscowoscPoczty_Nazwa>\r\n    <praw_adSiedzUlica_Nazwa>al.Niepodległości</praw_adSiedzUlica_Nazwa>\r\n    <praw_podstawowaFormaPrawna_Symbol>2</praw_podstawowaFormaPrawna_Symbol>\r\n    <praw_szczegolnaFormaPrawna_Symbol>01</praw_szczegolnaFormaPrawna_Symbol>\r\n    <praw_formaFinansowania_Symbol>2</praw_formaFinansowania_Symbol>\r\n    <praw_formaWlasnosci_Symbol>111</praw_formaWlasnosci_Symbol>\r\n    <praw_organZalozycielski_Symbol>050000000</praw_organZalozycielski_Symbol>\r\n    <praw_organRejestrowy_Symbol />\r\n    <praw_rodzajRejestruEwidencji_Symbol>000</praw_rodzajRejestruEwidencji_Symbol>\r\n    <praw_podstawowaFormaPrawna_Nazwa>JEDNOSTKA ORGANIZACYJNA NIEMAJĄCA OSOBOWOŚCI PRAWNEJ</praw_podstawowaFormaPrawna_Nazwa>\r\n    <praw_szczegolnaFormaPrawna_Nazwa>ORGANY WŁADZY,ADMINISTRACJI RZĄDOWEJ</praw_szczegolnaFormaPrawna_Nazwa>\r\n    <praw_formaFinansowania_Nazwa>JEDNOSTKA BUDŻETOWA</praw_formaFinansowania_Nazwa>\r\n    <praw_formaWlasnosci_Nazwa>WŁASNOŚĆ SKARBU PAŃSTWA</praw_formaWlasnosci_Nazwa>\r\n    <praw_organZalozycielski_Nazwa>PREZES GŁÓWNEGO URZĘDU STATYSTYCZNEGO</praw_organZalozycielski_Nazwa>\r\n    <praw_organRejestrowy_Nazwa />\r\n    <praw_rodzajRejestruEwidencji_Nazwa>PODMIOTY UTWORZONE Z MOCY USTAWY</praw_rodzajRejestruEwidencji_Nazwa>\r\n    <praw_jednostekLokalnych>0</praw_jednostekLokalnych>\r\n  </dane>";
            dane = dane.Replace("\r\n    ", "");
            var xml = InputDaneToDanePobierzPelnyRaportResponse(dane);

            var deserialization = new DeserializationRepository();
            var typ = CreateClassAndReadXml<TypJednostki>("P");
            var silosId = CreateClassAndReadXml<SilosId>("1");
            var nazwaRaportu = new NazwaRaportu(typ, silosId);

            //Act
            var result = deserialization.DeserializeResponseFromDanePobierzPelnyRaport(xml, nazwaRaportu);
            var company = new Company(result);

            //Assert
            Assert.IsType(typeof(DaneJednostkiPrawnej), result);
            Assert.Equal("GŁÓWNY URZĄD STATYSTYCZNY", company.Nazwa);
            Assert.Equal("PODMIOTY UTWORZONE Z MOCY USTAWY", company.RodzajRejestruEwidencjiNazwa); //pra.PrawRodzajRejestruEwidencjiNazwa
        }

        [Fact]
        public void Company_DaneJednostkiFizycznejCeidg_Correct()
        {
            //Arrange
            var dane = "<dane>\r\n    <fiz_regon9>444444444</fiz_regon9>\r\n    <fiz_nazwa>xxxxxxxxxxxxxx</fiz_nazwa>\r\n    <fiz_nazwaSkrocona>xxxxxxxxxxxxx</fiz_nazwaSkrocona>\r\n    <fiz_dataPowstania>2014-10-17</fiz_dataPowstania>\r\n    <fiz_dataRozpoczeciaDzialalnosci>2014-10-17</fiz_dataRozpoczeciaDzialalnosci>\r\n    <fiz_dataWpisuDoREGONDzialalnosci>2014-10-22</fiz_dataWpisuDoREGONDzialalnosci>\r\n    <fiz_dataZawieszeniaDzialalnosci />\r\n    <fiz_dataWznowieniaDzialalnosci />\r\n    <fiz_dataZaistnieniaZmianyDzialalnosci>2014-10-22</fiz_dataZaistnieniaZmianyDzialalnosci>\r\n    <fiz_dataZakonczeniaDzialalnosci />\r\n    <fiz_dataSkresleniazRegonDzialalnosci />\r\n    <fiz_adSiedzKraj_Symbol />\r\n    <fiz_adSiedzWojewodztwo_Symbol>02</fiz_adSiedzWojewodztwo_Symbol>\r\n    <fiz_adSiedzPowiat_Symbol>64</fiz_adSiedzPowiat_Symbol>\r\n    <fiz_adSiedzGmina_Symbol>039</fiz_adSiedzGmina_Symbol>\r\n    <fiz_adSiedzKodPocztowy>50430</fiz_adSiedzKodPocztowy>\r\n    <fiz_adSiedzMiejscowoscPoczty_Symbol>0986544</fiz_adSiedzMiejscowoscPoczty_Symbol>\r\n    <fiz_adSiedzMiejscowosc_Symbol>0986544</fiz_adSiedzMiejscowosc_Symbol>\r\n    <fiz_adSiedzUlica_Symbol>22571</fiz_adSiedzUlica_Symbol>\r\n    <fiz_adSiedzNumerNieruchomosci>199</fiz_adSiedzNumerNieruchomosci>\r\n    <fiz_adSiedzNumerLokalu>2        </fiz_adSiedzNumerLokalu>\r\n    <fiz_adSiedzNietypoweMiejsceLokalizacji />\r\n    <fiz_numerTelefonu />\r\n    <fiz_numerWewnetrznyTelefonu />\r\n    <fiz_numerFaksu />\r\n    <fiz_adresEmail />\r\n    <fiz_adresStronyinternetowej />\r\n    <fiz_adresEmail2 />\r\n    <fiz_adSiedzKraj_Nazwa />\r\n    <fiz_adSiedzWojewodztwo_Nazwa>DOLNOŚLĄSKIE</fiz_adSiedzWojewodztwo_Nazwa>\r\n    <fiz_adSiedzPowiat_Nazwa>m. Wrocław</fiz_adSiedzPowiat_Nazwa>\r\n    <fiz_adSiedzGmina_Nazwa>Wrocław-Krzyki</fiz_adSiedzGmina_Nazwa>\r\n    <fiz_adSiedzMiejscowosc_Nazwa>Wrocław</fiz_adSiedzMiejscowosc_Nazwa>\r\n    <fiz_adSiedzMiejscowoscPoczty_Nazwa>Wrocław</fiz_adSiedzMiejscowoscPoczty_Nazwa>\r\n    <fiz_adSiedzUlica_Nazwa>ul. Romualda Traugutta</fiz_adSiedzUlica_Nazwa>\r\n    <fizC_dataWpisuDoRejestruEwidencji>2014-10-17</fizC_dataWpisuDoRejestruEwidencji>\r\n    <fizC_numerwRejestrzeEwidencji>aaaaaaaaa/2014 </fizC_numerwRejestrzeEwidencji>\r\n    <fizC_OrganRejestrowy_Symbol>032000000</fizC_OrganRejestrowy_Symbol>\r\n    <fizC_OrganRejestrowy_Nazwa>MINISTER GOSPODARKI</fizC_OrganRejestrowy_Nazwa>\r\n    <fizC_RodzajRejestru_Symbol>151</fizC_RodzajRejestru_Symbol>\r\n    <fizC_RodzajRejestru_Nazwa>CENTRALNA EWIDENCJA I INFORMACJA O DZIAŁALNOŚCI GOSPODARCZEJ</fizC_RodzajRejestru_Nazwa>\r\n    <fizC_numerTelefonu />\r\n    <fizC_numerWewnetrznyTelefonu />\r\n    <fizC_numerFaksu />\r\n    <fizC_adresEmail />\r\n    <fizC_adresStronyInternetowej />\r\n  </dane>";
            dane = dane.Replace("\r\n    ", "");
            var xml = InputDaneToDanePobierzPelnyRaportResponse(dane);

            var deserialization = new DeserializationRepository();
            var typ = CreateClassAndReadXml<TypJednostki>("F");
            var silosId = CreateClassAndReadXml<SilosId>("1");
            var nazwaRaportu = new NazwaRaportu(typ, silosId);

            //Act
            var result = deserialization.DeserializeResponseFromDanePobierzPelnyRaport(xml, nazwaRaportu);
            var company = new Company(result);

            //Assert
            Assert.IsType(typeof(DaneJednostkiFizycznejCeidg), result);
            Assert.Equal("xxxxxxxxxxxxxx", company.Nazwa);
            Assert.Equal("CENTRALNA EWIDENCJA I INFORMACJA O DZIAŁALNOŚCI GOSPODARCZEJ", company.RodzajRejestruNazwa); //FizCRodzajRejestruNazwa
        }

        [Fact]
        public void Company_DaneJednostkiFizycznejRolnicza_Correct()
        {
            //Arrange
            var dane = "<dane>\r\n    <fiz_regon9>555555555</fiz_regon9>\r\n    <fiz_nazwa>GOSPODARSTWO ROLNE</fiz_nazwa>\r\n    <fiz_nazwaSkrocona />\r\n    <fiz_dataPowstania>2000-05-15</fiz_dataPowstania>\r\n    <fiz_dataRozpoczeciaDzialalnosci>2000-05-15</fiz_dataRozpoczeciaDzialalnosci>\r\n    <fiz_dataWpisuDoREGONDzialalnosci />\r\n    <fiz_dataZawieszeniaDzialalnosci />\r\n    <fiz_dataWznowieniaDzialalnosci />\r\n    <fiz_dataZaistnieniaZmianyDzialalnosci>2001-05-15</fiz_dataZaistnieniaZmianyDzialalnosci>\r\n    <fiz_dataZakonczeniaDzialalnosci />\r\n    <fiz_dataSkresleniazRegonDzialalnosci />\r\n    <fiz_adSiedzKraj_Symbol />\r\n    <fiz_adSiedzWojewodztwo_Symbol>30</fiz_adSiedzWojewodztwo_Symbol>\r\n    <fiz_adSiedzPowiat_Symbol>08</fiz_adSiedzPowiat_Symbol>\r\n    <fiz_adSiedzGmina_Symbol>049</fiz_adSiedzGmina_Symbol>\r\n    <fiz_adSiedzKodPocztowy>69600</fiz_adSiedzKodPocztowy>\r\n    <fiz_adSiedzMiejscowoscPoczty_Symbol>0202962</fiz_adSiedzMiejscowoscPoczty_Symbol>\r\n    <fiz_adSiedzMiejscowosc_Symbol>0203074</fiz_adSiedzMiejscowosc_Symbol>\r\n    <fiz_adSiedzUlica_Symbol />\r\n    <fiz_adSiedzNumerNieruchomosci>16</fiz_adSiedzNumerNieruchomosci>\r\n    <fiz_adSiedzNumerLokalu />\r\n    <fiz_adSiedzNietypoweMiejsceLokalizacji />\r\n    <fiz_numerTelefonu />\r\n    <fiz_numerWewnetrznyTelefonu />\r\n    <fiz_numerFaksu />\r\n    <fiz_adresEmail />\r\n    <fiz_adresStronyinternetowej />\r\n    <fiz_adresEmail2 />\r\n    <fiz_adSiedzKraj_Nazwa />\r\n    <fiz_adSiedzWojewodztwo_Nazwa>WIELKOPOLSKIE</fiz_adSiedzWojewodztwo_Nazwa>\r\n    <fiz_adSiedzPowiat_Nazwa>xxxxxxxx</fiz_adSiedzPowiat_Nazwa>\r\n    <fiz_adSiedzGmina_Nazwa>Yyyyyy</fiz_adSiedzGmina_Nazwa>\r\n    <fiz_adSiedzMiejscowosc_Nazwa>Zzzzzz</fiz_adSiedzMiejscowosc_Nazwa>\r\n    <fiz_adSiedzMiejscowoscPoczty_Nazwa>Yyyyyy</fiz_adSiedzMiejscowoscPoczty_Nazwa>\r\n    <fiz_adSiedzUlica_Nazwa />\r\n  </dane>";
            dane = dane.Replace("\r\n    ", "");
            var xml = InputDaneToDanePobierzPelnyRaportResponse(dane);

            var deserialization = new DeserializationRepository();
            var typ = CreateClassAndReadXml<TypJednostki>("F");
            var silosId = CreateClassAndReadXml<SilosId>("2");
            var nazwaRaportu = new NazwaRaportu(typ, silosId);

            //Act
            var result = deserialization.DeserializeResponseFromDanePobierzPelnyRaport(xml, nazwaRaportu);
            var company = new Company(result);

            //Assert
            Assert.IsType(typeof(DaneJednostkiFizycznejRolnicza), result);
            Assert.Equal("GOSPODARSTWO ROLNE", company.Nazwa);
            Assert.Equal("Yyyyyy", company.DaneAdresowe.Where(x => x.Typ == AdresTyp.Siedziba).First().MiejscowoscPocztyNazwa); //FizAdSiedzMiejscowoscPocztyNazwa
        }

        [Fact]
        public void Company_DaneJednostkiFizycznejPozostala_Correct()
        {
            //Arrange
            var dane = "<dane>\r\n    <fiz_regon9>666666666</fiz_regon9>\r\n    <fiz_nazwa>NIEPUBLICZNY ZAKŁAD OPIEKI ZDROWOTNEJ xxxxxxxxxxxxx</fiz_nazwa>\r\n    <fiz_nazwaSkrocona />\r\n    <fiz_dataPowstania>1993-03-20</fiz_dataPowstania>\r\n    <fiz_dataRozpoczeciaDzialalnosci>1999-10-20</fiz_dataRozpoczeciaDzialalnosci>\r\n    <fiz_dataWpisuDoREGONDzialalnosci />\r\n    <fiz_dataZawieszeniaDzialalnosci />\r\n    <fiz_dataWznowieniaDzialalnosci />\r\n    <fiz_dataZaistnieniaZmianyDzialalnosci>2011-08-16</fiz_dataZaistnieniaZmianyDzialalnosci>\r\n    <fiz_dataZakonczeniaDzialalnosci />\r\n    <fiz_dataSkresleniazRegonDzialalnosci />\r\n    <fiz_adSiedzKraj_Symbol />\r\n    <fiz_adSiedzWojewodztwo_Symbol>30</fiz_adSiedzWojewodztwo_Symbol>\r\n    <fiz_adSiedzPowiat_Symbol>22</fiz_adSiedzPowiat_Symbol>\r\n    <fiz_adSiedzGmina_Symbol>059</fiz_adSiedzGmina_Symbol>\r\n    <fiz_adSiedzKodPocztowy>69000</fiz_adSiedzKodPocztowy>\r\n    <fiz_adSiedzMiejscowoscPoczty_Symbol>0198380</fiz_adSiedzMiejscowoscPoczty_Symbol>\r\n    <fiz_adSiedzMiejscowosc_Symbol>0198380</fiz_adSiedzMiejscowosc_Symbol>\r\n    <fiz_adSiedzUlica_Symbol>1240</fiz_adSiedzUlica_Symbol>\r\n    <fiz_adSiedzNumerNieruchomosci>99</fiz_adSiedzNumerNieruchomosci>\r\n    <fiz_adSiedzNumerLokalu />\r\n    <fiz_adSiedzNietypoweMiejsceLokalizacji />\r\n    <fiz_numerTelefonu />\r\n    <fiz_numerWewnetrznyTelefonu />\r\n    <fiz_numerFaksu>9999999999</fiz_numerFaksu>\r\n    <fiz_adresEmail />\r\n    <fiz_adresStronyinternetowej />\r\n    <fiz_adresEmail2 />\r\n    <fiz_adSiedzKraj_Nazwa />\r\n    <fiz_adSiedzWojewodztwo_Nazwa>WIELKOPOLSKIE</fiz_adSiedzWojewodztwo_Nazwa>\r\n    <fiz_adSiedzPowiat_Nazwa>xxxxxxxxxx</fiz_adSiedzPowiat_Nazwa>\r\n    <fiz_adSiedzGmina_Nazwa>Yyyyyyyy</fiz_adSiedzGmina_Nazwa>\r\n    <fiz_adSiedzMiejscowosc_Nazwa>Yyyyyyyy</fiz_adSiedzMiejscowosc_Nazwa>\r\n    <fiz_adSiedzMiejscowoscPoczty_Nazwa>Yyyyyyyy</fiz_adSiedzMiejscowoscPoczty_Nazwa>\r\n    <fiz_adSiedzUlica_Nazwa>ul. Adama Mickiewicza</fiz_adSiedzUlica_Nazwa>\r\n    <fizP_dataWpisuDoRejestruEwidencji />\r\n    <fizP_numerwRejestrzeEwidencji />\r\n    <fizP_OrganRejestrowy_Symbol />\r\n    <fizP_OrganRejestrowy_Nazwa />\r\n    <fizP_RodzajRejestru_Symbol>099</fizP_RodzajRejestru_Symbol>\r\n    <fizP_RodzajRejestru_Nazwa>PODMIOTY NIE PODLEGAJĄCE WPISOM DO REJESTRU LUB EWIDENCJI</fizP_RodzajRejestru_Nazwa>\r\n  </dane>";
            dane = dane.Replace("\r\n    ", "");
            var xml = InputDaneToDanePobierzPelnyRaportResponse(dane);

            var deserialization = new DeserializationRepository();
            var typ = CreateClassAndReadXml<TypJednostki>("F");
            var silosId = CreateClassAndReadXml<SilosId>("3");
            var nazwaRaportu = new NazwaRaportu(typ, silosId);

            //Act
            var result = deserialization.DeserializeResponseFromDanePobierzPelnyRaport(xml, nazwaRaportu);
            var company = new Company(result);

            //Assert
            Assert.IsType(typeof(DaneJednostkiFizycznejPozostala), result);
            Assert.Equal("NIEPUBLICZNY ZAKŁAD OPIEKI ZDROWOTNEJ xxxxxxxxxxxxx", company.Nazwa);
            Assert.Equal("PODMIOTY NIE PODLEGAJĄCE WPISOM DO REJESTRU LUB EWIDENCJI", company.RodzajRejestruNazwa);//FizPRodzajRejestruNazwa
        }

        [Fact]
        public void Company_DaneJednostkiFizycznejWKrupgn_Correct()
        {
            //Arrange
            var dane = "<dane>\r\n    <fiz_regon9>777777777</fiz_regon9>\r\n    <fiz_nazwa>xxxxxxxxxxxxxxxx</fiz_nazwa>\r\n    <fiz_nazwaSkrocona />\r\n    <fiz_dataPowstania />\r\n    <fiz_dataRozpoczeciaDzialalnosci />\r\n    <fiz_dataWpisuDoREGONDzialalnosci />\r\n    <fiz_dataZawieszeniaDzialalnosci />\r\n    <fiz_dataWznowieniaDzialalnosci />\r\n    <fiz_dataZaistnieniaZmianyDzialalnosci />\r\n    <fiz_dataZakonczeniaDzialalnosci>2013-11-14</fiz_dataZakonczeniaDzialalnosci>\r\n    <fiz_dataSkresleniazRegonDzialalnosci />\r\n    <fiz_adSiedzKraj_Symbol />\r\n    <fiz_adSiedzWojewodztwo_Symbol>02</fiz_adSiedzWojewodztwo_Symbol>\r\n    <fiz_adSiedzPowiat_Symbol>64</fiz_adSiedzPowiat_Symbol>\r\n    <fiz_adSiedzGmina_Symbol>029</fiz_adSiedzGmina_Symbol>\r\n    <fiz_adSiedzKodPocztowy>54215</fiz_adSiedzKodPocztowy>\r\n    <fiz_adSiedzMiejscowoscPoczty_Symbol>0986290</fiz_adSiedzMiejscowoscPoczty_Symbol>\r\n    <fiz_adSiedzMiejscowosc_Symbol>0986290</fiz_adSiedzMiejscowosc_Symbol>\r\n    <fiz_adSiedzUlica_Symbol>02516</fiz_adSiedzUlica_Symbol>\r\n    <fiz_adSiedzNumerNieruchomosci>99</fiz_adSiedzNumerNieruchomosci>\r\n    <fiz_adSiedzNumerLokalu>99</fiz_adSiedzNumerLokalu>\r\n    <fiz_adSiedzNietypoweMiejsceLokalizacji />\r\n    <fiz_numerTelefonu />\r\n    <fiz_numerWewnetrznyTelefonu />\r\n    <fiz_numerFaksu />\r\n    <fiz_adresEmail />\r\n    <fiz_adresStronyinternetowej />\r\n    <fiz_adresEmail2 />\r\n    <fiz_adSiedzKraj_Nazwa />\r\n    <fiz_adSiedzWojewodztwo_Nazwa>DOLNOŚLĄSKIE</fiz_adSiedzWojewodztwo_Nazwa>\r\n    <fiz_adSiedzPowiat_Nazwa>m. Wrocław</fiz_adSiedzPowiat_Nazwa>\r\n    <fiz_adSiedzGmina_Nazwa>Wrocław-Fabryczna</fiz_adSiedzGmina_Nazwa>\r\n    <fiz_adSiedzMiejscowosc_Nazwa>Wrocław</fiz_adSiedzMiejscowosc_Nazwa>\r\n    <fiz_adSiedzMiejscowoscPoczty_Nazwa>Wrocław</fiz_adSiedzMiejscowoscPoczty_Nazwa>\r\n    <fiz_adSiedzUlica_Nazwa>ul. Bystrzycka</fiz_adSiedzUlica_Nazwa>\r\n  </dane>";
            dane = dane.Replace("\r\n    ", "");
            var xml = InputDaneToDanePobierzPelnyRaportResponse(dane);

            var deserialization = new DeserializationRepository();
            var typ = CreateClassAndReadXml<TypJednostki>("F");
            var silosId = CreateClassAndReadXml<SilosId>("4");
            var nazwaRaportu = new NazwaRaportu(typ, silosId);

            //Act
            var result = deserialization.DeserializeResponseFromDanePobierzPelnyRaport(xml, nazwaRaportu);
            var company = new Company(result);

            //Assert
            Assert.IsType(typeof(DaneJednostkiFizycznejWKrupgn), result);
            Assert.Equal("xxxxxxxxxxxxxxxx", company.Nazwa);
            Assert.Equal("ul. Bystrzycka", company.DaneAdresowe.Where(x => x.Typ == AdresTyp.Siedziba).First().UlicaNazwa);//fiz.FizAdSiedzUlicaNazwa
        }

        //Dane Syntestyczne, Wygenerowane na podstawie Pliku żrodłowego XML
        [Fact]
        public void Company_DaneJednostkiLokalnaFizycznej_Correct()
        {
            //Arrange
            var dane = "<dane>\r\n        <lokfiz_regon9>123456789</lokfiz_regon9>\r\n        <lokfiz_regon14>12345678901234</lokfiz_regon14>\r\n        <lokfiz_nazwa>Przykładowa Firma Sp. z o.o.</lokfiz_nazwa>\r\n        <lokfiz_silos_Symbol>ABC123</lokfiz_silos_Symbol>\r\n        <lokfiz_silos_Nazwa>Przykładowy Silos</lokfiz_silos_Nazwa>\r\n        \r\n        <lokfiz_adSiedzKraj_Symbol>PL</lokfiz_adSiedzKraj_Symbol>\r\n        <lokfiz_adSiedzWojewodztwo_Symbol>02</lokfiz_adSiedzWojewodztwo_Symbol>\r\n        <lokfiz_adSiedzPowiat_Symbol>01</lokfiz_adSiedzPowiat_Symbol>\r\n        <lokfiz_adSiedzGmina_Symbol>001</lokfiz_adSiedzGmina_Symbol>\r\n        <lokfiz_adSiedzKodPocztowy>00-001</lokfiz_adSiedzKodPocztowy>\r\n        <lokfiz_adSiedzMiejscowoscPoczty_Symbol>0001234</lokfiz_adSiedzMiejscowoscPoczty_Symbol>\r\n        <lokfiz_adSiedzMiejscowosc_Symbol>0005678</lokfiz_adSiedzMiejscowosc_Symbol>\r\n        <lokfiz_adSiedzUlica_Symbol>00089</lokfiz_adSiedzUlica_Symbol>\r\n        <lokfiz_adSiedzNumerNieruchomosci>10A</lokfiz_adSiedzNumerNieruchomosci>\r\n        <lokfiz_adSiedzNumerLokalu>4</lokfiz_adSiedzNumerLokalu>\r\n        <lokfiz_adSiedzNietypoweMiejsceLokalizacji>Wejście od tyłu</lokfiz_adSiedzNietypoweMiejsceLokalizacji>\r\n        <lokfiz_adSiedzKraj_Nazwa>Polska</lokfiz_adSiedzKraj_Nazwa>\r\n        <lokfiz_adSiedzWojewodztwo_Nazwa>Mazowieckie</lokfiz_adSiedzWojewodztwo_Nazwa>\r\n        <lokfiz_adSiedzPowiat_Nazwa>Warszawa</lokfiz_adSiedzPowiat_Nazwa>\r\n        <lokfiz_adSiedzGmina_Nazwa>Warszawa</lokfiz_adSiedzGmina_Nazwa>\r\n        <lokfiz_adSiedzMiejscowoscPoczty_Nazwa>Warszawa</lokfiz_adSiedzMiejscowoscPoczty_Nazwa>\r\n        <lokfiz_adSiedzMiejscowosc_Nazwa>Warszawa</lokfiz_adSiedzMiejscowosc_Nazwa>\r\n        <lokfiz_adSiedzUlica_Nazwa>Krucza</lokfiz_adSiedzUlica_Nazwa>\r\n\r\n        <lokfiz_dataPowstania>2020-01-01</lokfiz_dataPowstania>\r\n        <lokfiz_dataWpisuDoREGON>2020-01-15</lokfiz_dataWpisuDoREGON>\r\n        <lokfiz_dataRozpoczeciaDzialalnosci>2020-01-20</lokfiz_dataRozpoczeciaDzialalnosci>\r\n        <lokfiz_dataZawieszeniaDzialalnosci>2021-07-01</lokfiz_dataZawieszeniaDzialalnosci>\r\n        <lokfiz_dataWznowieniaDzialalnosci>2022-01-01</lokfiz_dataWznowieniaDzialalnosci>\r\n        <lokfiz_dataZaistnieniaZmiany>2023-03-10</lokfiz_dataZaistnieniaZmiany>\r\n        <lokfiz_dataZakonczeniaDzialalnosci>2024-01-01</lokfiz_dataZakonczeniaDzialalnosci>\r\n        <lokfiz_dataSkresleniazRegon>2024-02-01</lokfiz_dataSkresleniazRegon>\r\n\r\n        <lokfiz_formaFinansowania_Symbol>1</lokfiz_formaFinansowania_Symbol>\r\n        <lokfiz_formaFinansowania_Nazwa>Własność prywatna</lokfiz_formaFinansowania_Nazwa>\r\n\r\n        <lokfiz_dataWpisuDoRejestruEwidencji>2020-02-01</lokfiz_dataWpisuDoRejestruEwidencji>\r\n        <lokfiz_numerwRejestrzeEwidencji>12345</lokfiz_numerwRejestrzeEwidencji>\r\n        <lokfiz_organRejestrowy_Symbol>123456789</lokfiz_organRejestrowy_Symbol>\r\n        <lokfiz_organRejestrowy_Nazwa>Urząd Miasta Warszawa</lokfiz_organRejestrowy_Nazwa>\r\n        <lokfiz_rodzajRejestru_Symbol>REG</lokfiz_rodzajRejestru_Symbol>\r\n        <lokfiz_rodzajRejestru_Nazwa>Rejestr działalności gospodarczej</lokfiz_rodzajRejestru_Nazwa>\r\n        <lokfiz_dzialalnosci>1</lokfiz_dzialalnosci>\r\n    </dane>";
            dane = dane.Replace("\r\n    ", "");
            var xml = InputDaneToDanePobierzPelnyRaportResponse(dane);

            var deserialization = new DeserializationRepository();
            var typ = CreateClassAndReadXml<TypJednostki>("LF");
            var silosId = CreateClassAndReadXml<SilosId>("4");
            var nazwaRaportu = new NazwaRaportu(typ, silosId);

            //Act
            var result = deserialization.DeserializeResponseFromDanePobierzPelnyRaport(xml, nazwaRaportu);
            var company = new Company(result);

            //Assert
            Assert.IsType(typeof(DaneJednostkiLokalnaFizycznej), result);
            Assert.Equal("12345678901234", company.Regon);
            Assert.Equal("Rejestr działalności gospodarczej", company.RodzajRejestruNazwa);
        }

        //Dane Syntestyczne, Wygenerowane na podstawie Pliku żrodłowego XML
        [Fact]
        public void Company_DaneJednostkiLokalnaPrawnej_Correct()
        {
            //Arrange
            var dane = "<dane>\r\n    <lokpraw_regon14>12345678900000</lokpraw_regon14>\r\n    <lokpraw_nazwa>Przykładowa Firma Sp. z o.o.</lokpraw_nazwa>\r\n    <lokpraw_nip>1234567890</lokpraw_nip>\r\n    <lokpraw_numerWrejestrzeEwidencji>987654321098765</lokpraw_numerWrejestrzeEwidencji>\r\n    \r\n    <lokpraw_adSiedzKraj_Symbol>PL</lokpraw_adSiedzKraj_Symbol>\r\n    <lokpraw_adSiedzWojewodztwo_Symbol>02</lokpraw_adSiedzWojewodztwo_Symbol>\r\n    <lokpraw_adSiedzPowiat_Symbol>05</lokpraw_adSiedzPowiat_Symbol>\r\n    <lokpraw_adSiedzGmina_Symbol>123</lokpraw_adSiedzGmina_Symbol>\r\n    <lokpraw_adSiedzKodPocztowy>00-950</lokpraw_adSiedzKodPocztowy>\r\n    <lokpraw_adSiedzMiejscowoscPoczty_Symbol>0012345</lokpraw_adSiedzMiejscowoscPoczty_Symbol>\r\n    <lokpraw_adSiedzMiejscowosc_Symbol>0012345</lokpraw_adSiedzMiejscowosc_Symbol>\r\n    <lokpraw_adSiedzUlica_Symbol>00123</lokpraw_adSiedzUlica_Symbol>\r\n    <lokpraw_adSiedzNumerNieruchomosci>12A</lokpraw_adSiedzNumerNieruchomosci>\r\n    <lokpraw_adSiedzNumerLokalu>5</lokpraw_adSiedzNumerLokalu>\r\n    <lokpraw_adSiedzNietypoweMiejsceLokalizacji>Za rogiem koło parku</lokpraw_adSiedzNietypoweMiejsceLokalizacji>\r\n    \r\n    <lokpraw_adSiedzKraj_Nazwa>Polska</lokpraw_adSiedzKraj_Nazwa>\r\n    <lokpraw_adSiedzWojewodztwo_Nazwa>Mazowieckie</lokpraw_adSiedzWojewodztwo_Nazwa>\r\n    <lokpraw_adSiedzPowiat_Nazwa>Warszawski</lokpraw_adSiedzPowiat_Nazwa>\r\n    <lokpraw_adSiedzGmina_Nazwa>Warszawa</lokpraw_adSiedzGmina_Nazwa>\r\n    <lokpraw_adSiedzMiejscowoscPoczty_Nazwa>Warszawa</lokpraw_adSiedzMiejscowoscPoczty_Nazwa>\r\n    <lokpraw_adSiedzMiejscowosc_Nazwa>Warszawa</lokpraw_adSiedzMiejscowosc_Nazwa>\r\n    <lokpraw_adSiedzUlica_Nazwa>Nowa</lokpraw_adSiedzUlica_Nazwa>\r\n    \r\n    <lokpraw_dataWpisuDoRejestruEwidencji>2023-05-01</lokpraw_dataWpisuDoRejestruEwidencji>\r\n    <lokpraw_dataPowstania>2022-01-15</lokpraw_dataPowstania>\r\n    <lokpraw_dataRozpoczeciaDzialalnosci>2022-02-01</lokpraw_dataRozpoczeciaDzialalnosci>\r\n    <lokpraw_dataWpisuDoREGON>2022-02-05</lokpraw_dataWpisuDoREGON>\r\n    <lokpraw_dataZawieszeniaDzialalnosci>2023-10-01</lokpraw_dataZawieszeniaDzialalnosci>\r\n    <lokpraw_dataWznowieniaDzialalnosci>2023-12-01</lokpraw_dataWznowieniaDzialalnosci>\r\n    <lokpraw_dataZaistnieniaZmiany>2024-01-01</lokpraw_dataZaistnieniaZmiany>\r\n    <lokpraw_dataZakonczeniaDzialalnosci>2024-05-01</lokpraw_dataZakonczeniaDzialalnosci>\r\n    <lokpraw_dataSkresleniazRegon>2024-06-01</lokpraw_dataSkresleniazRegon>\r\n    \r\n    <lokpraw_podstawowaFormaPrawna_Symbol>101</lokpraw_podstawowaFormaPrawna_Symbol>\r\n    <lokpraw_szczegolnaFormaPrawna_Symbol>102</lokpraw_szczegolnaFormaPrawna_Symbol>\r\n    <lokpraw_formaFinansowania_Symbol>01234</lokpraw_formaFinansowania_Symbol>\r\n    <lokpraw_formaWlasnosci_Symbol>103</lokpraw_formaWlasnosci_Symbol>\r\n    <lokpraw_organZalozycielski_Symbol>987654321</lokpraw_organZalozycielski_Symbol>\r\n    <lokpraw_organRejestrowy_Symbol>123456789</lokpraw_organRejestrowy_Symbol>\r\n    <lokpraw_rodzajRejestruEwidencji_Symbol>201</lokpraw_rodzajRejestruEwidencji_Symbol>\r\n    \r\n    <lokpraw_podstawowaFormaPrawna_Nazwa>Spółka</lokpraw_podstawowaFormaPrawna_Nazwa>\r\n    <lokpraw_szczegolnaFormaPrawna_Nazwa>Akcyjna</lokpraw_szczegolnaFormaPrawna_Nazwa>\r\n    <lokpraw_formaFinansowania_Nazwa>Prywatna</lokpraw_formaFinansowania_Nazwa>\r\n    <lokpraw_formaWlasnosci_Nazwa>Prywatna</lokpraw_formaWlasnosci_Nazwa>\r\n    <lokpraw_organZalozycielski_Nazwa>Urząd Miasta</lokpraw_organZalozycielski_Nazwa>\r\n    <lokpraw_organRejestrowy_Nazwa>KRS</lokpraw_organRejestrowy_Nazwa>\r\n    <lokpraw_rodzajRejestruEwidencji_Nazwa>Handlowy</lokpraw_rodzajRejestruEwidencji_Nazwa>\r\n    \r\n    <lokpraw_dzialalnosci>2</lokpraw_dzialalnosci>\r\n</dane>\r\n";
            dane = dane.Replace("\r\n    ", "");
            var xml = InputDaneToDanePobierzPelnyRaportResponse(dane);

            var deserialization = new DeserializationRepository();
            var typ = CreateClassAndReadXml<TypJednostki>("LP");
            var silosId = CreateClassAndReadXml<SilosId>("4");
            var nazwaRaportu = new NazwaRaportu(typ, silosId);

            //Act
            var result = deserialization.DeserializeResponseFromDanePobierzPelnyRaport(xml, nazwaRaportu);
            var company = new Company(result);

            //Assert
            Assert.IsType(typeof(DaneJednostkiLokalnaPrawnej), result);
            Assert.Equal("123456789", company.Regon);
            Assert.Equal("Handlowy", company.RodzajRejestruEwidencjiNazwa); //LokprawRodzajRejestruEwidencjiNazwa
        }

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

        private string InputDaneToDanePobierzPelnyRaportResponse(string dane)
        {
            var xml = $"<s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\"><s:Header><a:Action s:mustUnderstand=\"1\">http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DanePobierzPelnyRaportResponse</a:Action></s:Header><s:Body><DanePobierzPelnyRaportResponse xmlns=\"http://CIS/BIR/PUBL/2014/07\"><DanePobierzPelnyRaportResult><root>{dane}</root></DanePobierzPelnyRaportResult></DanePobierzPelnyRaportResponse></s:Body></s:Envelope>";
            return xml;
        }
    }
}
