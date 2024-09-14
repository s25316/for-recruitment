using Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level4;
using System.Xml;
using System.Xml.Serialization;

namespace Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level3
{
    public class DanePobierzPelnyRaportResult
    {
        [XmlElement(ElementName = "root")]
        public Root Root { get; set; } = null!;
    }
}
