using Application.Database.Models.CompanyPart;

namespace Application.Database.Models.UniversityPart
{
    public class University
    {
        //FK Company
        public Guid Id { get; set; }
        public string UniversityType { get; set; } = null!;

        public virtual Company Company { get; set; } = null!;
        public virtual ICollection<EducationHistory> EducationHistories { get; set; } = new List<EducationHistory>();
    }
}
