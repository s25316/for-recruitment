using System.Xml;
using System.Xml.Serialization;

namespace Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level4
{
    public class Root
    {
        [XmlAnyElement]
        public XmlElement Dane { get; set; } = null!;
    }
}
/*
 * [XmlElement(ElementName = "dane")]
 */
