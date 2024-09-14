using Application.Database.Models.AddressPart;
using Application.Database.Models.DocumentPart;

namespace Application.Database.Models.PersonPart
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? HandName { get; set; } = null;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Pesel { get; set; } = null!;
        public string? LastPositionPep { get; set; } = null;

        //FK Address
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; } = null!;
        public virtual Employee? Employee { get; set; } = null;
        public virtual Client? Client { get; set; } = null;
        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
