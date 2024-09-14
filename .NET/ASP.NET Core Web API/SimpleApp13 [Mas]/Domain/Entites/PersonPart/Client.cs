using Domain.Entites.ContactPart;

namespace Domain.Entites.PersonPart
{
    public class Client
    {
        public Person Person { get; set; } = null!;
        public string AccountNumber { get; set; } = null!;

        //Refernces
        public Employee? Employee { get; set; } = null;
        public List<HistoryOfContactClient> HistoryOfContactClient { get; private set; } = new List<HistoryOfContactClient>();


        //Constructors
        public Client(Person p, string accountNumber)
        {
            Person = p;
            AccountNumber = accountNumber;

            //Throw if Client not null
            if (p.Client != null)
            {
                throw new Exception("Unable Create new Employee, Employee Person exist");
            }
            p.Client = this;
        }

        //CreateProfile() DB
    }
}
