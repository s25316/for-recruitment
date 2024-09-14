using Regon.ValueObjectsAndTheirExceptions.CustomDateOnlyXmlElement;
using System.Xml.Serialization;

namespace Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses
{
    [XmlRoot(ElementName = "dane", Namespace = "http://CIS/BIR/PUBL/2014/07")]
    public class DaneJednostkiPrawnej : DanePelne
    {
        [XmlElement(ElementName = "praw_regon14")]
        public string PrawRegon14 { get; set; } = null!;

        [XmlElement(ElementName = "praw_nip")]
        public string? PrawNip { get; set; } = null;

        [XmlElement(ElementName = "praw_nazwa")]
        public string PrawNazwa { get; set; } = null!;

        [XmlElement(ElementName = "praw_nazwaSkrocona")]
        public string? PrawNazwaSkrocona { get; set; } = null;

        [XmlElement(ElementName = "praw_numerWrejestrzeEwidencji")]
        public string? PrawNumerWrejestrzeEwidencji { get; set; } = null;

        [XmlElement(ElementName = "praw_dataPowstania")]
        public CustomDateOnly? PrawDataPowstania { get; set; } = null;

        [XmlElement(ElementName = "praw_dataRozpoczeciaDzialalnosci")]
        public CustomDateOnly? PrawDataRozpoczeciaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "praw_dataWpisuDoREGON")]
        public CustomDateOnly? PrawDataWpisuDoREGON { get; set; } = null;

        [XmlElement(ElementName = "praw_dataZawieszeniaDzialalnosci")]
        public CustomDateOnly? PrawDataZawieszeniaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "praw_dataWznowieniaDzialalnosci")]
        public CustomDateOnly? PrawDataWznowieniaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "praw_dataZaistnieniaZmiany")]
        public CustomDateOnly? PrawDataZaistnieniaZmiany { get; set; } = null;

        [XmlElement(ElementName = "praw_dataZakonczeniaDzialalnosci")]
        public CustomDateOnly? PrawDataZakonczeniaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "praw_dataSkresleniazRegon")]
        public CustomDateOnly? PrawDataSkresleniazRegon { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzKraj_Symbol")]
        public string? PrawAdSiedzKrajSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzWojewodztwo_Symbol")]
        public string? PrawAdSiedzWojewodztwoSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzPowiat_Symbol")]
        public string? PrawAdSiedzPowiatSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzGmina_Symbol")]
        public string? PrawAdSiedzGminaSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzKodPocztowy")]
        public string? PrawAdSiedzKodPocztowy { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzMiejscowoscPoczty_Symbol")]
        public string? PrawAdSiedzMiejscowoscPocztySymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzMiejscowosc_Symbol")]
        public string? PrawAdSiedzMiejscowoscSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzUlica_Symbol")]
        public string? PrawAdSiedzUlicaSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzNumerNieruchomosci")]
        public string? PrawAdSiedzNumerNieruchomosci { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzNumerLokalu")]
        public string? PrawAdSiedzNumerLokalu { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzNietypoweMiejsceLokalizacji")]
        public string? PrawAdSiedzNietypoweMiejsceLokalizacji { get; set; } = null;

        [XmlElement(ElementName = "praw_numerTelefonu")]
        public string? PrawNumerTelefonu { get; set; } = null;

        [XmlElement(ElementName = "praw_numerWewnetrznyTelefonu")]
        public string? PrawNumerWewnetrznyTelefonu { get; set; } = null;

        [XmlElement(ElementName = "praw_numerFaksu")]
        public string? PrawNumerFaksu { get; set; } = null;

        [XmlElement(ElementName = "praw_adresEmail")]
        public string? PrawAdresEmail { get; set; } = null;

        [XmlElement(ElementName = "praw_adresStronyinternetowej")]
        public string? PrawAdresStronyinternetowej { get; set; } = null;

        [XmlElement(ElementName = "praw_adresEmail2")]
        public string? PrawAdresEmail2 { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorKraj_Symbol")]
        public string? PrawAdKorKrajSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorWojewodztwo_Symbol")]
        public string? PrawAdKorWojewodztwoSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorPowiat_Symbol")]
        public string? PrawAdKorPowiatSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorGmina_Symbol")]
        public string? PrawAdKorGminaSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorKodPocztowy")]
        public string? PrawAdKorKodPocztowy { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorMiejscowosciPoczty_Symbol")]
        public string? PrawAdKorMiejscowosciPocztySymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorMiejscowosc_Symbol")]
        public string? PrawAdKorMiejscowoscSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorUlica_Symbol")]
        public string? PrawAdKorUlicaSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorNumerNieruchomosci")]
        public string? PrawAdKorNumerNieruchomosci { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorNumerLokalu")]
        public string? PrawAdKorNumerLokalu { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorNietypoweMiejsceLokalizacji")]
        public string? PrawAdKorNietypoweMiejsceLokalizacji { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorNazwaPodmiotuDoKorespondencji")]
        public string? PrawAdKorNazwaPodmiotuDoKorespondencji { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzKraj_Nazwa")]
        public string? PrawAdSiedzKrajNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzWojewodztwo_Nazwa")]
        public string? PrawAdSiedzWojewodztwoNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzPowiat_Nazwa")]
        public string? PrawAdSiedzPowiatNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzGmina_Nazwa")]
        public string? PrawAdSiedzGminaNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzMiejscowosc_Nazwa")]
        public string? PrawAdSiedzMiejscowoscNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzMiejscowoscPoczty_Nazwa")]
        public string? PrawAdSiedzMiejscowoscPocztyNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_adSiedzUlica_Nazwa")]
        public string? PrawAdSiedzUlicaNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorKraj_Nazwa")]
        public string? PrawAdKorKrajNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorWojewodztwo_Nazwa")]
        public string? PrawAdKorWojewodztwoNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorPowiat_Nazwa")]
        public string? PrawAdKorPowiatNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorGmina_Nazwa")]
        public string? PrawAdKorGminaNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorMiejscowosc_Nazwa")]
        public string? PrawAdKorMiejscowoscNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorMiejscowoscPoczty_Nazwa")]
        public string? PrawAdKorMiejscowoscPocztyNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_adKorUlica_Nazwa")]
        public string? PrawAdKorUlicaNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_podstawowaFormaPrawna_Symbol")]
        public string? PrawPodstawowaFormaPrawnaSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_szczegolnaFormaPrawna_Symbol")]
        public string? PrawSzczegolnaFormaPrawnaSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_formaFinansowania_Symbol")]
        public string? PrawFormaFinansowaniaSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_formaWlasnosci_Symbol")]
        public string? PrawFormaWlasnosciSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_organZalozycielski_Symbol")]
        public string? PrawOrganZalozycielskiSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_organRejestrowy_Symbol")]
        public string? PrawOrganRejestrowySymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_rodzajRejestruEwidencji_Symbol")]
        public string? PrawRodzajRejestruEwidencjiSymbol { get; set; } = null;

        [XmlElement(ElementName = "praw_podstawowaFormaPrawna_Nazwa")]
        public string? PrawPodstawowaFormaPrawnaNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_szczegolnaFormaPrawna_Nazwa")]
        public string? PrawSzczegolnaFormaPrawnaNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_formaFinansowania_Nazwa")]
        public string? PrawFormaFinansowaniaNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_formaWlasnosci_Nazwa")]
        public string? PrawFormaWlasnosciNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_organZalozycielski_Nazwa")]
        public string? PrawOrganZalozycielskiNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_organRejestrowy_Nazwa")]
        public string? PrawOrganRejestrowyNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_rodzajRejestruEwidencji_Nazwa")]
        public string? PrawRodzajRejestruEwidencjiNazwa { get; set; } = null;

        [XmlElement(ElementName = "praw_jednostekLokalnych")]
        public int? PrawJednostekLokalnych { get; set; } = null;

        [XmlElement(ElementName = "praw_dataWpisuDoRejestruEwidencji")]
        public CustomDateOnly? PrawDataWpisuDoRejestruEwidencji { get; set; } = null;
    }
}
