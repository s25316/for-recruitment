using Application.Database.Models.ContactPart;

namespace Application.Database.Models.PersonPart
{
    public class Client
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; } = null!;

        //FK
        public Guid EmploeeId { get; set; }
        public virtual Employee? Employee { get; set; } = null;
        public virtual Person Person { get; set; } = null!;

        public virtual ICollection<HistoryOfContactClient> HistoryOfContactClients { get; set; } = new List<HistoryOfContactClient>();

    }
}
