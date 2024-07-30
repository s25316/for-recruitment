using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SimpleApp12__APIs_.ValidationAttributes
{
    public class RegonValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) { return false; }
            if (value.GetType() != typeof(string)) { return false; }
            var regon = (string)value;

            //var regex = new Regex(@"^[0-9]{9}$");
            var regex = new Regex(@"^(\d{9}|\d{14})$");
            return regex.IsMatch(regon);
        }

        public override string FormatErrorMessage(string name)
        {
            return "REGON składa sie z 9 lub 14 cyfr";
        }
    }
}
