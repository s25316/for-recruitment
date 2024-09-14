using Regon.Factories;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Regon.ValueObjectsAndTheirExceptions.TypJednostkiValue
{
    /// <summary>
    /// Typ Jednostki: prawna, fizyczna, lokalna jednostki prawnej, lokalna jednostki fizycznej
    /// </summary>
    /// <exception cref="TypJednostkiException"></exception>
    public record TypJednostki : IXmlSerializable
    {
        public string Value { get; private set; } = null!;
        public string Description { get; private set; } = null!;

        //===========================================================================================================
        //===========================================================================================================
        //XML adapter
        //===========================================================================================================
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

        //===========================================================================================================
        //===========================================================================================================
        //Private Methods
        //===========================================================================================================
        private string GetDescriptionByValue(string value)
        {
            var descriptionDictionary = new Dictionary<string, string>
            {
                { "P", "jednostka prawna" },
                { "F", "jednostka fizyczna (os. fizyczna prowadząca działalność gospodarczą)" },
                { "LP", "jednostka lokalna jednostki prawnej" },
                { "LF", "jednostka lokalna jednostki fizycznej" }
            };
            if (descriptionDictionary.TryGetValue(value.ToUpper(), out var description))
            {
                return description;
            }
            throw new TypJednostkiException(MessagesFactory.GenerateExeptionMessageTypJednostkiNewValue
                (
                this.GetType(),
                MethodBase.GetCurrentMethod(),
                value
                ));
        }
    }
}
