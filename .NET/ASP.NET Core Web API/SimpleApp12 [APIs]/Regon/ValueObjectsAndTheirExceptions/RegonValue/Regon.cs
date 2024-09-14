using Regon.Factories;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Regon.ValueObjectsAndTheirExceptions.RegonValue
{
    /// <summary>
    /// Niepowtarzalny numer nadawany podmiotom gospodarki narodowej i jednostkom lokalnym tych podmiotów w krajowym rejestrze urzędowym podmiotów gospodarki narodowej REGON, niemający ukrytego lub jawnego charakteru znaczącego, określającego cechy podmiotu.
    /// </summary>
    /// <exception cref="RegonException"></exception>
    public record Regon : IXmlSerializable
    {
        private string _number = null!;
        public string Number
        {
            get { return _number; }
            set
            {
                value = RemoveCharacters(value);
                if (!IsCorrectValue(value))
                {
                    throw new RegonException(MessagesFactory.GenerateExeptionMessageRegonIncorrect(value));
                }
                _number = value;
            }
        }

        //===========================================================================================================
        //===========================================================================================================
        //XML adapter
        //===========================================================================================================
        public XmlSchema? GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            Number = reader.ReadElementContentAsString();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(Number);
        }

        //===========================================================================================================
        //===========================================================================================================
        //Private Methods
        //===========================================================================================================
        private string RemoveCharacters(string value)
        {
            return value
                .Replace("-", "")
                .Replace(" ", "")
                .Trim();
        }
        private bool IsCorrectValue(string regon)
        {
            var regex = new Regex(@"^(\d{9}|\d{14})$");
            return regex.IsMatch(regon);
        }
    }
}
