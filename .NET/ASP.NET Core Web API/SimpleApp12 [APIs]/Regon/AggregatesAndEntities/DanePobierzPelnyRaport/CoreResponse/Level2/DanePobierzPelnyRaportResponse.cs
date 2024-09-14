using Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level3;
using System.Xml.Serialization;

namespace Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level2
{
    public class DanePobierzPelnyRaportResponse
    {
        [XmlElement(ElementName = "DanePobierzPelnyRaportResult", Namespace = "http://CIS/BIR/PUBL/2014/07")]
        public DanePobierzPelnyRaportResult DanePobierzPelnyRaportResult { get; set; } = null!;
    }
}
