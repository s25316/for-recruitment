using Regon.AggregatesAndEntities.DaneSzukaj.CoreResponse.Level5;
using System.Xml.Serialization;

namespace Regon.AggregatesAndEntities.DaneSzukaj.CoreResponse.Level4
{
    public class Root
    {
        [XmlElement(ElementName = "dane")]
        public DanePodstawowe Dane { get; set; } = null!;
    }
}
//public List<DanePodstawowe> Dane { get; set; } = new ();
