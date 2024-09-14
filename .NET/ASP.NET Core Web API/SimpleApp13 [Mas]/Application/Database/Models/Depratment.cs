using Application.Database.Models.AddressPart;
using Application.Database.Models.ContactPart;
using Application.Database.Models.PersonPart;

namespace Application.Database.Models
{
    public class Depratment
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        //FK Address
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public virtual ICollection<Employee> Managers { get; set; } = new List<Employee>();

        public virtual ICollection<HistoryOfContactClient> HistoryOfContactClients { get; set; } = new List<HistoryOfContactClient>();
        public virtual ICollection<HistoryOfContactCompany> HistoryOfContactCompanies { get; set; } = new List<HistoryOfContactCompany>();
    }
}
