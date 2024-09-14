using Regon.Factories;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Regon.ValueObjectsAndTheirExceptions.CustomDateOnlyXmlElement
{
    public record CustomDateOnly : IXmlSerializable
    {
        public DateOnly? DateOnly { get; private set; } = null;

        //===========================================================================================================
        //===========================================================================================================
        //XML adapter
        //===========================================================================================================
        public XmlSchema? GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            var data = reader.ReadElementContentAsString();

            data = data.Trim();

            if (string.IsNullOrEmpty(data))
            {
                DateOnly = null;
            }
            else if (DateTime.TryParse(data, out DateTime date))
            {
                DateOnly = System.DateOnly.FromDateTime(date);
            }
            else
            {
                throw new CustomDateOnlyException(MessagesFactory.GenerateExeptionMessageCustomDateOnlyIncorrect(data));
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(DateOnly.ToString());
        }
    }
}
