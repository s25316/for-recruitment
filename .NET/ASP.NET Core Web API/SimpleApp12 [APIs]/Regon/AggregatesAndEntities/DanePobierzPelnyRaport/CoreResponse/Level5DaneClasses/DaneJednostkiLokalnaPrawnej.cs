using Regon.ValueObjectsAndTheirExceptions.CustomDateOnlyXmlElement;
using System.Xml.Serialization;

namespace Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses
{
    [XmlRoot(ElementName = "dane", Namespace = "http://CIS/BIR/PUBL/2014/07")]
    public class DaneJednostkiLokalnaPrawnej : DanePelne
    {
        [XmlElement(ElementName = "lokpraw_regon14")]
        public string LokprawRegon14 { get; set; } = null!;

        [XmlElement(ElementName = "lokpraw_nazwa")]
        public string LokprawNazwa { get; set; } = null!;

        [XmlElement(ElementName = "lokpraw_nip")]
        public string? LokprawNip { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_numerWrejestrzeEwidencji")]
        public string? LokprawNumerWrejestrzeEwidencji { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzKraj_Symbol")]
        public string? LokprawAdSiedzKrajSymbol { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzWojewodztwo_Symbol")]
        public string? LokprawAdSiedzWojewodztwoSymbol { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzPowiat_Symbol")]
        public string? LokprawAdSiedzPowiatSymbol { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzGmina_Symbol")]
        public string? LokprawAdSiedzGminaSymbol { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzKodPocztowy")]
        public string? LokprawAdSiedzKodPocztowy { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzMiejscowoscPoczty_Symbol")]
        public string? LokprawAdSiedzMiejscowoscPocztySymbol { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzMiejscowosc_Symbol")]
        public string? LokprawAdSiedzMiejscowoscSymbol { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzUlica_Symbol")]
        public string? LokprawAdSiedzUlicaSymbol { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzNumerNieruchomosci")]
        public string? LokprawAdSiedzNumerNieruchomosci { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzNumerLokalu")]
        public string? LokprawAdSiedzNumerLokalu { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzNietypoweMiejsceLokalizacji")]
        public string? LokprawAdSiedzNietypoweMiejsceLokalizacji { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzKraj_Nazwa")]
        public string? LokprawAdSiedzKrajNazwa { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzWojewodztwo_Nazwa")]
        public string? LokprawAdSiedzWojewodztwoNazwa { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzPowiat_Nazwa")]
        public string? LokprawAdSiedzPowiatNazwa { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzGmina_Nazwa")]
        public string? LokprawAdSiedzGminaNazwa { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzMiejscowoscPoczty_Nazwa")]
        public string? LokprawAdSiedzMiejscowoscPocztyNazwa { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzMiejscowosc_Nazwa")]
        public string? LokprawAdSiedzMiejscowoscNazwa { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_adSiedzUlica_Nazwa")]
        public string? LokprawAdSiedzUlicaNazwa { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_dataWpisuDoRejestruEwidencji")]
        public CustomDateOnly? LokprawDataWpisuDoRejestruEwidencji { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_dataPowstania")]
        public CustomDateOnly? LokprawDataPowstania { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_dataRozpoczeciaDzialalnosci")]
        public CustomDateOnly? LokprawDataRozpoczeciaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_dataWpisuDoREGON")]
        public CustomDateOnly? LokprawDataWpisuDoREGON { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_dataZawieszeniaDzialalnosci")]
        public CustomDateOnly? LokprawDataZawieszeniaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_dataWznowieniaDzialalnosci")]
        public CustomDateOnly? LokprawDataWznowieniaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_dataZaistnieniaZmiany")]
        public CustomDateOnly? LokprawDataZaistnieniaZmiany { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_dataZakonczeniaDzialalnosci")]
        public CustomDateOnly? LokprawDataZakonczeniaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_dataSkresleniazRegon")]
        public CustomDateOnly? LokprawDataSkresleniazRegon { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_podstawowaFormaPrawna_Symbol")]
        public string? LokprawPodstawowaFormaPrawnaSymbol { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_szczegolnaFormaPrawna_Symbol")]
        public string? LokprawSzczegolnaFormaPrawnaSymbol { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_formaFinansowania_Symbol")]
        public string? LokprawFormaFinansowaniaSymbol { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_formaWlasnosci_Symbol")]
        public string? LokprawFormaWlasnosciSymbol { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_organZalozycielski_Symbol")]
        public string? LokprawOrganZalozycielskiSymbol { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_organRejestrowy_Symbol")]
        public string? LokprawOrganRejestrowySymbol { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_rodzajRejestruEwidencji_Symbol")]
        public string? LokprawRodzajRejestruEwidencjiSymbol { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_podstawowaFormaPrawna_Nazwa")]
        public string? LokprawPodstawowaFormaPrawnaNazwa { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_szczegolnaFormaPrawna_Nazwa")]
        public string? LokprawSzczegolnaFormaPrawnaNazwa { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_formaFinansowania_Nazwa")]
        public string? LokprawFormaFinansowaniaNazwa { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_formaWlasnosci_Nazwa")]
        public string? LokprawFormaWlasnosciNazwa { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_organZalozycielski_Nazwa")]
        public string? LokprawOrganZalozycielskiNazwa { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_organRejestrowy_Nazwa")]
        public string? LokprawOrganRejestrowyNazwa { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_rodzajRejestruEwidencji_Nazwa")]
        public string? LokprawRodzajRejestruEwidencjiNazwa { get; set; } = null;

        [XmlElement(ElementName = "lokpraw_dzialalnosci")]
        public int? LokprawDzialalnosci { get; set; } = null;
    }
}
