using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public record Nip
    {
        public string Value { get; private set; } = null!;

        public Nip(string value)
        {
            var regex = new Regex(@"^[0-9]{10}$");
            if (!regex.IsMatch(value))
            {
                throw new Exception("incorrect NIP, NIP contains only 10 numbers");
            }
            Value = value;
        }
    }
}
