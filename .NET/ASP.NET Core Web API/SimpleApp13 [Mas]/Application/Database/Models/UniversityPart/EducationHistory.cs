using Application.Database.Models.PersonPart;

namespace Application.Database.Models.UniversityPart
{
    public class EducationHistory
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; } = null;
        public string Fild { get; set; } = null!;
        public string Degree { get; set; } = null!;
        public string Corse { get; set; } = null!;


        //FK Employee
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;
        //FK University
        public Guid UniversityId { get; set; }
        public virtual University University { get; set; } = null!;
    }
}
