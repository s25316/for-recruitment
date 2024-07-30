using Regon.Models.ResponseDaneSzukaj.Level4;
using System.Xml.Serialization;

namespace Regon.Models.ResponseDaneSzukaj.Level3
{
    public class DaneSzukajResult
    {
        [XmlElement(ElementName = "root")]
        public Root root { get; set; } = null!;
    }
}
