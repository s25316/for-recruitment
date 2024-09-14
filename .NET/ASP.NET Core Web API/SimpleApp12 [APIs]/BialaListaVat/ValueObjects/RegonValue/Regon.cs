using System.Text.RegularExpressions;

namespace BialaListaVat.ValueObjects.RegonValue
{
    /// <summary>
    /// Niepowtarzalny numer nadawany podmiotom gospodarki narodowej i jednostkom lokalnym tych podmiotów w krajowym rejestrze urzędowym podmiotów gospodarki narodowej REGON, niemający ukrytego lub jawnego charakteru znaczącego, określającego cechy podmiotu.
    /// </summary>
    /// <exception cref="RegonException"></exception>
    public record Regon
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
                    throw new RegonException(Messages.RegonExeption);
                }
                _number = value;
            }
        }

        public Regon(string regon)
        {
            Number = regon;
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
