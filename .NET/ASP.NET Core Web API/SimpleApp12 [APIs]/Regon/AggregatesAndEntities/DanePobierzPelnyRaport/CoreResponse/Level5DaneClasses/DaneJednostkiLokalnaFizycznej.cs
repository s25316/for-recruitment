using Regon.ValueObjectsAndTheirExceptions.CustomDateOnlyXmlElement;
using System.Xml.Serialization;

namespace Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses
{
    [XmlRoot(ElementName = "dane", Namespace = "http://CIS/BIR/PUBL/2014/07")]
    public class DaneJednostkiLokalnaFizycznej : DanePelne
    {
        [XmlElement(ElementName = "lokfiz_regon9")]
        public string Lokfiz_regon9 { get; set; } = null!;

        [XmlElement(ElementName = "lokfiz_regon14")]
        public string Lokfiz_regon14 { get; set; } = null!;

        [XmlElement(ElementName = "lokfiz_nazwa")]
        public string Lokfiz_nazwa { get; set; } = null!;

        [XmlElement(ElementName = "lokfiz_silos_Symbol")]
        public string? Lokfiz_silos_Symbol { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_silos_Nazwa")]
        public string? Lokfiz_silos_Nazwa { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzKraj_Symbol")]
        public string? Lokfiz_adSiedzKraj_Symbol { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzWojewodztwo_Symbol")]
        public string? Lokfiz_adSiedzWojewodztwo_Symbol { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzPowiat_Symbol")]
        public string? Lokfiz_adSiedzPowiat_Symbol { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzGmina_Symbol")]
        public string? Lokfiz_adSiedzGmina_Symbol { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzKodPocztowy")]
        public string? Lokfiz_adSiedzKodPocztowy { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzMiejscowoscPoczty_Symbol")]
        public string? Lokfiz_adSiedzMiejscowoscPoczty_Symbol { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzMiejscowosc_Symbol")]
        public string? Lokfiz_adSiedzMiejscowosc_Symbol { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzUlica_Symbol")]
        public string? Lokfiz_adSiedzUlica_Symbol { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzNumerNieruchomosci")]
        public string? Lokfiz_adSiedzNumerNieruchomosci { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzNumerLokalu")]
        public string? Lokfiz_adSiedzNumerLokalu { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzNietypoweMiejsceLokalizacji")]
        public string? Lokfiz_adSiedzNietypoweMiejsceLokalizacji { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzKraj_Nazwa")]
        public string? Lokfiz_adSiedzKraj_Nazwa { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzWojewodztwo_Nazwa")]
        public string? Lokfiz_adSiedzWojewodztwo_Nazwa { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzPowiat_Nazwa")]
        public string? Lokfiz_adSiedzPowiat_Nazwa { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzGmina_Nazwa")]
        public string? Lokfiz_adSiedzGmina_Nazwa { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzMiejscowoscPoczty_Nazwa")]
        public string? Lokfiz_adSiedzMiejscowoscPoczty_Nazwa { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzMiejscowosc_Nazwa")]
        public string? Lokfiz_adSiedzMiejscowosc_Nazwa { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_adSiedzUlica_Nazwa")]
        public string? Lokfiz_adSiedzUlica_Nazwa { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_dataPowstania")]
        public CustomDateOnly? Lokfiz_dataPowstania { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_dataWpisuDoREGON")]
        public CustomDateOnly? Lokfiz_dataWpisuDoREGON { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_dataRozpoczeciaDzialalnosci")]
        public CustomDateOnly? Lokfiz_dataRozpoczeciaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_dataZawieszeniaDzialalnosci")]
        public CustomDateOnly? Lokfiz_dataZawieszeniaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_dataWznowieniaDzialalnosci")]
        public CustomDateOnly? Lokfiz_dataWznowieniaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_dataZaistnieniaZmiany")]
        public CustomDateOnly? Lokfiz_dataZaistnieniaZmiany { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_dataZakonczeniaDzialalnosci")]
        public CustomDateOnly? Lokfiz_dataZakonczeniaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_dataSkresleniazRegon")]
        public CustomDateOnly? Lokfiz_dataSkresleniazRegon { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_formaFinansowania_Symbol")]
        public string? Lokfiz_formaFinansowania_Symbol { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_formaFinansowania_Nazwa")]
        public string? Lokfiz_formaFinansowania_Nazwa { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_dataWpisuDoRejestruEwidencji")]
        public CustomDateOnly? Lokfiz_dataWpisuDoRejestruEwidencji { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_numerwRejestrzeEwidencji")]
        public string? Lokfiz_numerwRejestrzeEwidencji { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_organRejestrowy_Symbol")]
        public string? Lokfiz_organRejestrowy_Symbol { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_organRejestrowy_Nazwa")]
        public string? Lokfiz_organRejestrowy_Nazwa { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_rodzajRejestru_Symbol")]
        public string? Lokfiz_rodzajRejestru_Symbol { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_rodzajRejestru_Nazwa")]
        public string? Lokfiz_rodzajRejestru_Nazwa { get; set; } = null;

        [XmlElement(ElementName = "lokfiz_dzialalnosci")]
        public int? Lokfiz_dzialalnosci { get; set; } = null;
    }
}
