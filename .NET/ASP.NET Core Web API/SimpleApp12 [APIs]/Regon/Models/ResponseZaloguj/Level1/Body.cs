using System.Xml.Serialization;
using Regon.Models.ResponseZaloguj.Level2;

namespace Regon.Models.ResponseZaloguj.Level1
{
    public class Body
    {
        [XmlElement(ElementName = "ZalogujResponse", Namespace = "http://CIS/BIR/PUBL/2014/07")]
        public ZalogujResponse ZalogujResponse { get; set; } = null!;
    }
}
