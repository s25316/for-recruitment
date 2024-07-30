using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SimpleApp12__APIs_.ValidationAttributes
{
    public class NipValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) { return false; }
            if (value.GetType() != typeof(string)) { return false; }
            var nip = (string)value;

            var regex = new Regex(@"^[0-9]{10}$");
            return regex.IsMatch(nip);
        }

        public override string FormatErrorMessage(string name)
        {
            return "NIP składa sie z 10 cyfr";
        }
    }
}
