using System.Xml.Serialization;

namespace Regon.AggregatesAndEntities.Wyloguj.CoreResponse.Level2
{
    public class WylogujResponse
    {
        [XmlElement(ElementName = "WylogujResult")]
        public bool WylogujResult { get; set; }
    }
}
