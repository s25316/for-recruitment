using Domain.Entites.ContactPart;

namespace Domain.Entites.CompanyPart
{
    public class Company
    {

        public Guid? Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Nip { get; set; } = null; //Nie wszytskie firmy moga posiadac 
        public string? Regon { get; set; } = null; //Nie wszytskie firmy
        public string Status { get; set; } = null!;

        //Exist if IsOurClient == true
        public bool IsOurClient { get; set; }
        public string? Email { get; set; } = null;



        //Refeences
        public List<EmploymentHistory> EmploymentHistory { get; private set; } = new List<EmploymentHistory>();
        public List<HistoryOfContactCompany> HistoryOfContactCompany { get; private set; } = new List<HistoryOfContactCompany>();

        //Methods
        //Save()
        //GetByNip(Nip)
        public void SetEmploymentHistory(EmploymentHistory employmentHistory)
        {
            EmploymentHistory.Add(employmentHistory);
        }

    }
}
