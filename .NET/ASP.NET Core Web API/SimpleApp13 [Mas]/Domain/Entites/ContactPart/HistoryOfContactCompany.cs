using Domain.Entites.CompanyPart;

namespace Domain.Entites.ContactPart
{
    public class HistoryOfContactCompany : HistoryOfContact
    {
        public Depratment Depratment { get; private set; } = null!;
        public Company Company { get; private set; } = null!;

        //Constructor
        public HistoryOfContactCompany
            (
            string firstMessage,
            Depratment depratment,
            Company company
            ) : base(firstMessage)
        {
            Depratment = depratment;
            Company = company;

            company.HistoryOfContactCompany.Add(this);
            depratment.HistoryOfContactCompany.Add(this);
        }
    }
}
