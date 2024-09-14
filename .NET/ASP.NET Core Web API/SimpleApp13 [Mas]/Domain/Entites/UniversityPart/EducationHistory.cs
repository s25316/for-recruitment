using Domain.Entites.PersonPart;

namespace Domain.Entites.UniversityPart
{
    public class EducationHistory
    {
        public Guid? Id { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; } = null;
        public string Fild { get; set; } = null!;
        public string Degree { get; set; } = null!;
        public string Corse { get; set; } = null!;

        //References
        public University University { get; private set; } = null!;
        public Employee Employee { get; private set; } = null!;

        //Cornstructors
        public EducationHistory
            (
            DateTime from,
            DateTime? to,
            string fild,
            string degree,
            string corse,
            University university,
            Employee employee
            )
        {
            From = from;
            To = to;
            Fild = fild;
            Degree = degree;
            Corse = corse;
            University = university;
            Employee = employee;

            employee.SetEducationHistory(this);
            university.SetEducationHistory(this);
        }

        //Methods
        //Save()
        public bool IsCompleted()
        {
            var today = DateTime.Today;
            return To == null || To > today;
        }
    }
}
