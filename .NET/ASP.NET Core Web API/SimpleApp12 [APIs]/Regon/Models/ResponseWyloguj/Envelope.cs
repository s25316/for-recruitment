using Regon.Models.ResponseWyloguj.Level1;
using System.Xml.Serialization;

namespace Regon.Models.ResponseWyloguj
{
    [XmlRoot(ElementName = "Envelope", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class Envelope
    {
        [XmlElement(ElementName = "Header", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
        public Header Header { get; set; } = null!;

        [XmlElement(ElementName = "Body", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
        public Body Body { get; set; } = null!;
    }
}
