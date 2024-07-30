using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Regon.ValueObjectsAndTheirExceptions.TypJednostkiValue
{
    public record TypJednostki : IXmlSerializable
    {
        public string Value { get; private set; } = null!;
        public string Description { get; private set; } = null!;

        public XmlSchema? GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            Value = reader.ReadElementContentAsString();
            Description = GetDescriptionByValue(Value);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(Description);
        }

        private string GetDescriptionByValue(string value) 
        {
            var descriptionDictionary = new Dictionary<string, string>
            {
                { "P", "jednostka prawna" },
                { "F", "jednostka fizyczna (os. fizyczna prowadząca działalność gospodarczą)" },
                { "LP", "jednostka lokalna jednostki prawnej" },
                { "LF", "jednostka lokalna jednostki fizycznej" }
            };
            if (descriptionDictionary.TryGetValue(value, out var description))
            {
                return description;
            }
            throw new TypJednostkiException(Messages.TypInResponseDaneHasChanged);
        }
    }
}
