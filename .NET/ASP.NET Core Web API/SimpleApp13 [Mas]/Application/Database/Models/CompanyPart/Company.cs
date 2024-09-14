using Application.Database.Models.ContactPart;
using Application.Database.Models.UniversityPart;

namespace Application.Database.Models.CompanyPart
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Nip { get; set; } = null; //Nie wszytskie firmy moga posiadac 
        public string? Regon { get; set; } = null; //Nie wszytskie firmy
        public string Status { get; set; } = null!;
        public bool IsOurClient { get; set; }
        public string? Email { get; set; } = null;

        public virtual University? University { get; set; } = null;
        public virtual ICollection<EmploymentHistory> EmploymentHistories { get; set; } = new List<EmploymentHistory>();
        public virtual ICollection<HistoryOfContactCompany> HistoryOfContactCompanies { get; set; } = new List<HistoryOfContactCompany>();
    }
}
