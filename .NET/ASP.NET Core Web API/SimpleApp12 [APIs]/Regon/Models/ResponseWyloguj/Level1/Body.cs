using Regon.Models.ResponseWyloguj.Level2;
using System.Xml.Serialization;

namespace Regon.Models.ResponseWyloguj.Level1
{
    public class Body
    {
        [XmlElement(ElementName = "WylogujResponse", Namespace = "http://CIS/BIR/PUBL/2014/07")]
        public WylogujResponse WylogujResponse { get; set; } = null!;
    }
}
