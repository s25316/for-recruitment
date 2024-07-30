using System.Xml.Serialization;

namespace Regon.Models.ResponseWyloguj.Level2
{
    public class WylogujResponse
    {
        [XmlElement(ElementName = "WylogujResult")]
        public bool WylogujResult { get; set; }
    }
}
