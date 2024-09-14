using Domain.Entites.PersonPart;

namespace Domain.Entites.CompanyPart
{
    public class EmploymentHistory
    {
        private readonly Dictionary<string, string> _colidationCompanies = new Dictionary<string, string>();

        public DateTime From { get; set; }
        public DateTime? To { get; set; } = null;
        public string Position { get; set; } = null!;

        //References
        public Employee Employee { get; private set; } = null!;
        public Company Company { get; private set; } = null!;


        //Constructor
        public EmploymentHistory
            (
            DateTime from,
            DateTime? to,
            string position,
            Employee employee,
            Company company
            )
        {
            From = from;
            To = to;
            Position = position;
            Employee = employee;
            Company = company;

            Employee.SetEmploymentHistory(this);
            Company.SetEmploymentHistory(this);

            _colidationCompanies.Add("010816248", "010816248");
            _colidationCompanies.Add("000001353", "010816248");
            _colidationCompanies.Add("000001554", "010816248");
        }

        //Methods
        public bool IsColision()
        {
            var regon = Company.Regon;
            var today = DateTime.Today;
            if (
                _colidationCompanies.TryGetValue(regon, out var comany) &&
                (To == null || To > today)
                )
            {
                return true;
            }
            return false;
        }

    }
}
