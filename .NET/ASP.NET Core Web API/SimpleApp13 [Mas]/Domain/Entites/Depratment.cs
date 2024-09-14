using Domain.Entites.CompanyPart;
using Domain.Entites.ContactPart;
using Domain.Entites.PersonPart;

namespace Domain.Entites
{
    public class Depratment
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        //Adress

        //References
        //subset
        public List<Employee> Employees { get; private set; } = new List<Employee>();
        public List<Employee> Managers { get; private set; } = new List<Employee>();

        //XOR
        public List<HistoryOfContactCompany> HistoryOfContactCompany { get; private set; } = new List<HistoryOfContactCompany>();
        public List<HistoryOfContactClient> HistoryOfContactClient { get; private set; } = new List<HistoryOfContactClient>();


        //Methods
        //Save ()
        public bool SendMessageToClient(string text, Client client)
        {
            if (HistoryOfContactCompany.Any())
            {
                return false;
            }
            var x = new HistoryOfContactClient(text, this, client);
            return true;
        }

        public bool SendMessageToCompany(string text, Company company)
        {
            if (HistoryOfContactClient.Any())
            {
                return false;
            }
            var x = new HistoryOfContactCompany(text, this, company);
            return true;
        }
    }
}
