using Regon.Models.ResponseDaneSzukaj.Level3;
using System.Xml.Serialization;

namespace Regon.Models.ResponseDaneSzukaj.Level2
{
    public class DaneSzukajResponse
    {
        [XmlElement(ElementName = "DaneSzukajResult")]
        public DaneSzukajResult DaneSzukajResult { get; set; } = null!;
    }
}
