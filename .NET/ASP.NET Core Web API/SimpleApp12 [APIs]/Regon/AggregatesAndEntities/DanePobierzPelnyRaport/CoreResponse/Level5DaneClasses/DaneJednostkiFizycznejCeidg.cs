using Regon.ValueObjectsAndTheirExceptions.CustomDateOnlyXmlElement;
using System.Xml.Serialization;

namespace Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses
{
    [XmlRoot(ElementName = "dane", Namespace = "http://CIS/BIR/PUBL/2014/07")]
    public class DaneJednostkiFizycznejCeidg : DanePelne
    {
        [XmlElement(ElementName = "fiz_regon9")]
        public string FizRegon9 { get; set; } = null!;

        [XmlElement(ElementName = "fiz_nazwa")]
        public string FizNazwa { get; set; } = null!;

        [XmlElement(ElementName = "fiz_nazwaSkrocona", IsNullable = true)]
        public string? FizNazwaSkrocona { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzKraj_Symbol", IsNullable = true)]
        public string? FizAdSiedzKrajSymbol { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzWojewodztwo_Symbol", IsNullable = true)]
        public string? FizAdSiedzWojewodztwoSymbol { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzPowiat_Symbol", IsNullable = true)]
        public string? FizAdSiedzPowiatSymbol { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzGmina_Symbol", IsNullable = true)]
        public string? FizAdSiedzGminaSymbol { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzKodPocztowy", IsNullable = true)]
        public string? FizAdSiedzKodPocztowy { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzMiejscowoscPoczty_Symbol", IsNullable = true)]
        public string? FizAdSiedzMiejscowoscPocztySymbol { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzMiejscowosc_Symbol", IsNullable = true)]
        public string? FizAdSiedzMiejscowoscSymbol { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzUlica_Symbol", IsNullable = true)]
        public string? FizAdSiedzUlicaSymbol { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzNumerNieruchomosci", IsNullable = true)]
        public string? FizAdSiedzNumerNieruchomosci { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzNumerLokalu", IsNullable = true)]
        public string? FizAdSiedzNumerLokalu { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzNietypoweMiejsceLokalizacji", IsNullable = true)]
        public string? FizAdSiedzNietypoweMiejsceLokalizacji { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzKraj_Nazwa", IsNullable = true)]
        public string? FizAdSiedzKrajNazwa { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzWojewodztwo_Nazwa", IsNullable = true)]
        public string? FizAdSiedzWojewodztwoNazwa { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzPowiat_Nazwa", IsNullable = true)]
        public string? FizAdSiedzPowiatNazwa { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzGmina_Nazwa", IsNullable = true)]
        public string? FizAdSiedzGminaNazwa { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzMiejscowoscPoczty_Nazwa", IsNullable = true)]
        public string? FizAdSiedzMiejscowoscPocztyNazwa { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzMiejscowosc_Nazwa", IsNullable = true)]
        public string? FizAdSiedzMiejscowoscNazwa { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzUlica_Nazwa", IsNullable = true)]
        public string? FizAdSiedzUlicaNazwa { get; set; } = null;

        [XmlElement(ElementName = "fiz_numerTelefonu", IsNullable = true)]
        public string? FizNumerTelefonu { get; set; } = null;

        [XmlElement(ElementName = "fiz_numerWewnetrznyTelefonu", IsNullable = true)]
        public string? FizNumerWewnetrznyTelefonu { get; set; } = null;

        [XmlElement(ElementName = "fiz_numerFaksu", IsNullable = true)]
        public string? FizNumerFaksu { get; set; } = null;

        [XmlElement(ElementName = "fiz_adresEmail", IsNullable = true)]
        public string? FizAdresEmail { get; set; } = null;

        [XmlElement(ElementName = "fiz_adresStronyinternetowej", IsNullable = true)]
        public string? FizAdresStronyinternetowej { get; set; } = null;

        [XmlElement(ElementName = "fiz_adresEmail2", IsNullable = true)]
        public string? FizAdresEmail2 { get; set; } = null;

        [XmlElement(ElementName = "fiz_dataPowstania", IsNullable = true)]
        public CustomDateOnly? FizDataPowstania { get; set; } = null;

        [XmlElement(ElementName = "fiz_dataRozpoczeciaDzialalnosci", IsNullable = true)]
        public CustomDateOnly? FizDataRozpoczeciaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "fiz_dataWpisuDoREGONDzialalnosci", IsNullable = true)]
        public CustomDateOnly? FizDataWpisuDoREGONDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "fiz_dataZawieszeniaDzialalnosci", IsNullable = true)]
        public CustomDateOnly? FizDataZawieszeniaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "fiz_dataWznowieniaDzialalnosci", IsNullable = true)]
        public CustomDateOnly? FizDataWznowieniaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "fiz_dataZaistnieniaZmianyDzialalnosci", IsNullable = true)]
        public CustomDateOnly? FizDataZaistnieniaZmianyDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "fiz_dataZakonczeniaDzialalnosci", IsNullable = true)]
        public CustomDateOnly? FizDataZakonczeniaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "fiz_dataSkresleniazRegonDzialalnosci", IsNullable = true)]
        public CustomDateOnly? FizDataSkresleniazRegonDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "fizC_dataWpisuDoRejestruEwidencji", IsNullable = true)]
        public CustomDateOnly? FizCDataWpisuDoRejestruEwidencji { get; set; } = null;

        [XmlElement(ElementName = "fizC_numerwRejestrzeEwidencji", IsNullable = true)]
        public string? FizCNumerwRejestrzeEwidencji { get; set; } = null;

        [XmlElement(ElementName = "fizC_OrganRejestrowy_Symbol", IsNullable = true)]
        public string? FizCOrganRejestrowySymbol { get; set; } = null;

        [XmlElement(ElementName = "fizC_OrganRejestrowy_Nazwa", IsNullable = true)]
        public string? FizCOrganRejestrowyNazwa { get; set; } = null;

        [XmlElement(ElementName = "fizC_RodzajRejestru_Symbol", IsNullable = true)]
        public string? FizCRodzajRejestruSymbol { get; set; } = null;

        [XmlElement(ElementName = "fizC_RodzajRejestru_Nazwa", IsNullable = true)]
        public string? FizCRodzajRejestruNazwa { get; set; } = null;

        [XmlElement(ElementName = "fizC_numerTelefonu", IsNullable = true)]
        public string? FizCNumerTelefonu { get; set; } = null;

        [XmlElement(ElementName = "fizC_numerWewnetrznyTelefonu", IsNullable = true)]
        public string? FizCNumerWewnetrznyTelefonu { get; set; } = null;

        [XmlElement(ElementName = "fizC_numerFaksu", IsNullable = true)]
        public string? FizCNumerFaksu { get; set; } = null;

        [XmlElement(ElementName = "fizC_adresEmail", IsNullable = true)]
        public string? FizCAdresEmail { get; set; } = null;

        [XmlElement(ElementName = "fizC_adresStronyInternetowej", IsNullable = true)]
        public string? FizCAdresStronyInternetowej { get; set; } = null;
    }
}
