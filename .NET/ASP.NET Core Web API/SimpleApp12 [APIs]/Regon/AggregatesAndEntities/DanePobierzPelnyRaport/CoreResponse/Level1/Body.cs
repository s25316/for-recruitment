using Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level2;
using System.Xml.Serialization;

namespace Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level1
{
    public class Body
    {
        [XmlElement(ElementName = "DanePobierzPelnyRaportResponse", Namespace = "http://CIS/BIR/PUBL/2014/07")]
        public DanePobierzPelnyRaportResponse DanePobierzPelnyRaportResponse { get; set; } = null!;
    }
}
