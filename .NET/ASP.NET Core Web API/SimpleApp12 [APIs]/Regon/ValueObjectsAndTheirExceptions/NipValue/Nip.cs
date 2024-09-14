using Regon.Factories;
using System.Text.RegularExpressions;

namespace Regon.ValueObjectsAndTheirExceptions.NipValue
{
    /// <summary>
    /// Numer identyfikacji podatkowej (NIP) – dziesięciocyfrowy kod, służący do identyfikacji podatników w Polsce.
    /// </summary>
    /// <exception cref="NipException"></exception>
    public record Nip
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
                    throw new NipException(MessagesFactory.GenerateExeptionMessageNipIncorrect(value));
                }
                _number = value;
            }
        }

        public Nip(string nip)
        {
            Number = nip;
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

        private bool IsCorrectValue(string nip)
        {
            var regex = new Regex(@"^[0-9]{10}$");
            return regex.IsMatch(nip);
        }
    }
}
