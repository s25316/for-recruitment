using Regon.AggregatesAndEntities.DaneSzukaj.CoreResponse.Level3;
using System.Xml.Serialization;

namespace Regon.AggregatesAndEntities.DaneSzukaj.CoreResponse.Level2
{
    public class DaneSzukajResponse
    {
        [XmlElement(ElementName = "DaneSzukajResult")]
        public DaneSzukajResult DaneSzukajResult { get; set; } = null!;
    }
}
