using System.Xml.Serialization;

namespace Regon.AggregatesAndEntities.Zaloguj.CoreResponse.Level2
{
    public class ZalogujResponse
    {
        [XmlElement(ElementName = "ZalogujResult")]
        public string? ZalogujResult { get; set; } = null;
    }
}
