using Regon.AggregatesAndEntities.DaneSzukaj.CoreResponse.Level4;
using System.Xml.Serialization;

namespace Regon.AggregatesAndEntities.DaneSzukaj.CoreResponse.Level3
{
    public class DaneSzukajResult
    {
        [XmlElement(ElementName = "root")]
        public Root Root { get; set; } = null!;
    }
}
