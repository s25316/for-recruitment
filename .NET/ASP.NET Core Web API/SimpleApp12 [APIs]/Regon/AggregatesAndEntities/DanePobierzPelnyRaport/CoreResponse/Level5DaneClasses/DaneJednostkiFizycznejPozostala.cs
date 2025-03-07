﻿using Regon.ValueObjectsAndTheirExceptions.CustomDateOnlyXmlElement;
using System.Xml.Serialization;

namespace Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses
{
    [XmlRoot(ElementName = "dane", Namespace = "http://CIS/BIR/PUBL/2014/07")]
    public class DaneJednostkiFizycznejPozostala : DanePelne
    {
        [XmlElement(ElementName = "fiz_regon9")]
        public string FizRegon9 { get; set; } = null!;

        [XmlElement(ElementName = "fiz_nazwa")]
        public string FizNazwa { get; set; } = null!;

        [XmlElement(ElementName = "fiz_nazwaSkrocona")]
        public string? FizNazwaSkrocona { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzKraj_Symbol")]
        public string? FizAdSiedzKrajSymbol { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzWojewodztwo_Symbol")]
        public string? FizAdSiedzWojewodztwoSymbol { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzPowiat_Symbol")]
        public string? FizAdSiedzPowiatSymbol { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzGmina_Symbol")]
        public string? FizAdSiedzGminaSymbol { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzKodPocztowy")]
        public string? FizAdSiedzKodPocztowy { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzMiejscowoscPoczty_Symbol")]
        public string? FizAdSiedzMiejscowoscPocztySymbol { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzMiejscowosc_Symbol")]
        public string? FizAdSiedzMiejscowoscSymbol { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzUlica_Symbol")]
        public string? FizAdSiedzUlicaSymbol { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzNumerNieruchomosci")]
        public string? FizAdSiedzNumerNieruchomosci { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzNumerLokalu")]
        public string? FizAdSiedzNumerLokalu { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzNietypoweMiejsceLokalizacji")]
        public string? FizAdSiedzNietypoweMiejsceLokalizacji { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzKraj_Nazwa")]
        public string? FizAdSiedzKrajNazwa { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzWojewodztwo_Nazwa")]
        public string? FizAdSiedzWojewodztwoNazwa { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzPowiat_Nazwa")]
        public string? FizAdSiedzPowiatNazwa { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzGmina_Nazwa")]
        public string? FizAdSiedzGminaNazwa { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzMiejscowoscPoczty_Nazwa")]
        public string? FizAdSiedzMiejscowoscPocztyNazwa { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzMiejscowosc_Nazwa")]
        public string? FizAdSiedzMiejscowoscNazwa { get; set; } = null;

        [XmlElement(ElementName = "fiz_adSiedzUlica_Nazwa")]
        public string? FizAdSiedzUlicaNazwa { get; set; } = null;

        [XmlElement(ElementName = "fiz_numerTelefonu")]
        public string? FizNumerTelefonu { get; set; } = null;

        [XmlElement(ElementName = "fiz_numerWewnetrznyTelefonu")]
        public string? FizNumerWewnetrznyTelefonu { get; set; } = null;

        [XmlElement(ElementName = "fiz_numerFaksu")]
        public string? FizNumerFaksu { get; set; } = null;

        [XmlElement(ElementName = "fiz_adresEmail")]
        public string? FizAdresEmail { get; set; } = null;

        [XmlElement(ElementName = "fiz_adresStronyinternetowej")]
        public string? FizAdresStronyinternetowej { get; set; } = null;

        [XmlElement(ElementName = "fiz_adresEmail2")]
        public string? FizAdresEmail2 { get; set; } = null;

        [XmlElement(ElementName = "fiz_dataPowstania")]
        public CustomDateOnly FizDataPowstania { get; set; } = null!;

        [XmlElement(ElementName = "fiz_dataRozpoczeciaDzialalnosci")]
        public CustomDateOnly? FizDataRozpoczeciaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "fiz_dataWpisuDoREGONDzialalnosci")]
        public CustomDateOnly? FizDataWpisuDoREGONDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "fiz_dataZawieszeniaDzialalnosci")]
        public CustomDateOnly? FizDataZawieszeniaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "fiz_dataWznowieniaDzialalnosci")]
        public CustomDateOnly? FizDataWznowieniaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "fiz_dataZaistnieniaZmianyDzialalnosci")]
        public CustomDateOnly? FizDataZaistnieniaZmianyDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "fiz_dataZakonczeniaDzialalnosci")]
        public CustomDateOnly? FizDataZakonczeniaDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "fiz_dataSkresleniazRegonDzialalnosci")]
        public CustomDateOnly? FizDataSkresleniazRegonDzialalnosci { get; set; } = null;

        [XmlElement(ElementName = "fizP_dataWpisuDoRejestruEwidencji")]
        public CustomDateOnly? FizPDataWpisuDoRejestruEwidencji { get; set; } = null;

        [XmlElement(ElementName = "fizP_numerwRejestrzeEwidencji")]
        public string? FizPNumerwRejestrzeEwidencji { get; set; } = null;

        [XmlElement(ElementName = "fizP_OrganRejestrowy_Symbol")]
        public string? FizPOrganRejestrowySymbol { get; set; } = null;

        [XmlElement(ElementName = "fizP_OrganRejestrowy_Nazwa")]
        public string? FizPOrganRejestrowyNazwa { get; set; } = null;

        [XmlElement(ElementName = "fizP_RodzajRejestru_Symbol")]
        public string? FizPRodzajRejestruSymbol { get; set; } = null;

        [XmlElement(ElementName = "fizP_RodzajRejestru_Nazwa")]
        public string? FizPRodzajRejestruNazwa { get; set; } = null;
    }
}
