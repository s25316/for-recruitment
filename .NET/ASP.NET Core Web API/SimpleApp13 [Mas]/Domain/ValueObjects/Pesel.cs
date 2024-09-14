using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public record Pesel
    {
        public string Value { get; private set; } = null!;

        public Pesel(string value)
        {
            var regex = new Regex(@"^[0-9]{11}$");
            if (!regex.IsMatch(value))
            {
                throw new Exception("Pesel contains Only 11 numbers");
            }
            Value = value;
        }
    }
}
