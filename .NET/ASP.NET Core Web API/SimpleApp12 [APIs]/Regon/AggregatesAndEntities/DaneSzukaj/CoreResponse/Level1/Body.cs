using Regon.AggregatesAndEntities.DaneSzukaj.CoreResponse.Level2;
using System.Xml.Serialization;

namespace Regon.AggregatesAndEntities.DaneSzukaj.CoreResponse.Level1
{
    public class Body
    {
        [XmlElement(ElementName = "DaneSzukajResponse", Namespace = "http://CIS/BIR/PUBL/2014/07")]
        public DaneSzukajResponse DaneSzukajResponse { get; set; } = null!;
    }
}
