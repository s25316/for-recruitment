using Domain.Entites.CompanyPart;

namespace Domain.Entites.UniversityPart
{
    public class University : Company
    {
        public string UniversityType { get; set; } = null!;

        //References
        public List<EducationHistory> EducationHistory { get; set; } = new List<EducationHistory>();

        //Methods
        public void SetEducationHistory(EducationHistory educationHistory)
        {
            EducationHistory.Add(educationHistory);
        }
    }
}
