using System.ComponentModel.DataAnnotations;

namespace SimpleApp06__EF__CdF_.ValidationAtributes
{
    public class YearAtribute : ValidationAttribute
    {
       public override bool IsValid(object? value)
        {

            if (value == null) return false;
            if (value.GetType() != typeof(int)) return false;
            var year = (int)value;
            if (year > DateTime.Now.Year) return false;
            
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Year should be less or this Year";
        }
    }
}
