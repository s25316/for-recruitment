using System.Xml.Serialization;

namespace Regon.Models.ResponseZaloguj.Level2
{
    public class ZalogujResponse
    {
        [XmlElement(ElementName = "ZalogujResult")]
        public string? ZalogujResult { get; set; } = null;
    }
}
