using System.Text.RegularExpressions;

namespace BialaListaVat.ValueObjects.RegonValue
{
    public record Regon
    {
        public string Number { get; private set; }

        public Regon(string regon) 
        {
            var regex = new Regex(@"^(\d{9}|\d{14})$");
            if (!regex.IsMatch(regon)) 
            {
                throw new RegonException("Niepoprawny REGON");
            }
            Number = regon;
        }

        public static explicit operator Regon(string regon) 
        { 
            return new Regon(regon);
        }
    }
}
