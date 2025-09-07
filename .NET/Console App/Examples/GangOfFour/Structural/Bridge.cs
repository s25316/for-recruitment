// Ignore spelling: Json
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;

namespace GangOfFour.Structural
{
    public interface IItem
    {
        string Get();
    }

    public class AccountantDocument : IItem
    {
        public string Get() => "... Example 1";
    }

    public class InformalDocument : IItem
    {
        public string Get() => "... Example 2";
    }

    public interface IBridge
    {
        string Prepare();
    }

    public class BridgeJsonDocument(IItem item) : IBridge
    {
        public string Prepare()
        {
            var itemValue = item.Get();
            var json = JsonDocument.Parse(itemValue) ?? throw new JsonException();
            return json.ToString() ?? throw new JsonException();
        }
    }

    public class BridgeXmlDocument(IItem item) : IBridge
    {
        public string Prepare()
        {
            var itemValue = item.Get();
            var xml = XDocument.Parse(itemValue) ?? throw new XmlException();
            return xml.ToString();
        }
    }
}
