using Regon.CustomExceptions;
using Regon.ValueObjectsAndTheirExceptions.SilosIdValue;
using Regon.ValueObjectsAndTheirExceptions.TypJednostkiValue;
using System.Resources;
using System.Xml.Serialization;

namespace Regon.Models.ResponseDaneSzukaj.Level5
{
    public class Dane
    {
        [XmlElement(ElementName = "Regon")]
        public string? Regon { get; set; } = null;

        [XmlElement(ElementName = "RegonLink")]
        public string? RegonLink { get; set; } = null;

        [XmlElement(ElementName = "Nazwa")]
        public string? Nazwa { get; set; } = null;

        [XmlElement(ElementName = "Wojewodztwo")]
        public string? Wojewodztwo { get; set; } = null;

        [XmlElement(ElementName = "Powiat")]
        public string? Powiat { get; set; } = null;

        [XmlElement(ElementName = "Gmina")]
        public string? Gmina { get; set; } = null;

        [XmlElement(ElementName = "Miejscowosc")]
        public string? Miejscowosc { get; set; } = null;

        [XmlElement(ElementName = "KodPocztowy")]
        public string? KodPocztowy { get; set; } = null;

        [XmlElement(ElementName = "Ulica")]
        public string? Ulica { get; set; } = null;

        private TypJednostki _typ = null!;

        [XmlElement(ElementName = "Typ")]
        public TypJednostki Typ {  get; set; } = null!;

        [XmlElement(ElementName = "SilosID")]
        public SilosId SilosID { get; set; } = null!;
    }
}
