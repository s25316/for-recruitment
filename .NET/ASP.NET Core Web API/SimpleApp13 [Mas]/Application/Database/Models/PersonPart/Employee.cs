using Application.Database.Models.CompanyPart;
using Application.Database.Models.UniversityPart;

namespace Application.Database.Models.PersonPart
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Position { get; set; } = null!;
        public string Competences { get; set; } = null!;

        public virtual Person Person { get; set; } = null!;
        public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
        public virtual ICollection<EmploymentHistory> EmploymentHistories { get; set; } = new List<EmploymentHistory>();
        public virtual ICollection<EducationHistory> EducationHistories { get; set; } = new List<EducationHistory>();

        public virtual ICollection<Depratment> EmployeeDepratments { get; set; } = new List<Depratment>();
        public virtual ICollection<Depratment> ManagerDepratments { get; set; } = new List<Depratment>();
    }
}
