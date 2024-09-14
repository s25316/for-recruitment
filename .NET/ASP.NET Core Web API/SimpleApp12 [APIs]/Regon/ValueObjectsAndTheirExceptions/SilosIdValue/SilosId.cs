using Regon.Factories;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Regon.ValueObjectsAndTheirExceptions.SilosIdValue
{
    /// <summary>
    /// Miejsce prowadzenia działalności
    /// </summary>
    /// <exception cref="SilosIdException"></exception>
    public record SilosId : IXmlSerializable
    {
        public int Value { get; private set; }
        public string Description { get; private set; } = null!;
        //===========================================================================================================
        //===========================================================================================================
        //Xml Adapter
        //===========================================================================================================
        public XmlSchema? GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            Value = reader.ReadElementContentAsInt();
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
        private string GetDescriptionByValue(int value)
        {
            var descriptionDictionary = new Dictionary<int, string>
            {
                { 1, "Miejsce prowadzenia działalności zarejestrowanej w CEIDG" }, // (tylko typy F i LF))
                { 2, "Miejsce prowadzenia działalności rolniczej" },// (tylko typy F i LF))
                { 3, "Miejsce prowadzenia działalności pozostałej" },//  (tylko typy F i LF))
                { 4, "Miejsce prowadzenia działalności zlikwidowanej w starym systemie KRUPGN" },
                { 6, "Miejsce prowadzenia działalności jednostki prawnej" }, //(tylko typy P i LP)
            };
            if (descriptionDictionary.TryGetValue(value, out var description))
            {
                return description;
            }
            throw new SilosIdException(MessagesFactory.GenerateExeptionMessageSilosIdNewValue
                (
                this.GetType(),
                MethodBase.GetCurrentMethod(),
                value
                ));
        }
    }
}
