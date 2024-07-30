using System.Text.RegularExpressions;

namespace Regon.ValueObjectsAndTheirExceptions.NipValue
{
    public record Nip
    {
        public string Number { get; private set; }

        public Nip(string nip)
        {
            var regex = new Regex(@"^[0-9]{10}$");
            if (!regex.IsMatch(nip))
            {
                throw new NipException("Niepoprawny NIP");
            }
            Number = nip;
        }

        public static explicit operator Nip(string nip)
        {
            return new Nip(nip);
        }
    }
}
