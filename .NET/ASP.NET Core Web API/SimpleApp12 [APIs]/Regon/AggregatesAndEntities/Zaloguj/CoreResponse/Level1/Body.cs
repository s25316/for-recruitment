using Regon.AggregatesAndEntities.Zaloguj.CoreResponse.Level2;
using System.Xml.Serialization;

namespace Regon.AggregatesAndEntities.Zaloguj.CoreResponse.Level1
{
    public class Body
    {
        [XmlElement(ElementName = "ZalogujResponse", Namespace = "http://CIS/BIR/PUBL/2014/07")]
        public ZalogujResponse ZalogujResponse { get; set; } = null!;
    }
}
