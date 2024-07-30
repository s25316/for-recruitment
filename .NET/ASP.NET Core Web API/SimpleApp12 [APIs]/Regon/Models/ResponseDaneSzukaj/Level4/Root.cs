using Regon.Models.ResponseDaneSzukaj.Level5;
using System.Xml.Serialization;

namespace Regon.Models.ResponseDaneSzukaj.Level4
{
    public class Root
    {
        [XmlElement(ElementName = "dane")]
        public List<Dane> dane { get; set; } = new ();
    }
}
