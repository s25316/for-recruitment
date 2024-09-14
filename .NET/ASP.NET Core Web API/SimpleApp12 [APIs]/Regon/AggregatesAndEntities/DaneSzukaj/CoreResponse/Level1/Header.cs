using System.Xml.Serialization;

namespace Regon.AggregatesAndEntities.DaneSzukaj.CoreResponse.Level1
{
    public class Header
    {
        [XmlElement(ElementName = "Action", Namespace = "http://www.w3.org/2005/08/addressing")]
        public string Action { get; set; } = null!;
    }
}
