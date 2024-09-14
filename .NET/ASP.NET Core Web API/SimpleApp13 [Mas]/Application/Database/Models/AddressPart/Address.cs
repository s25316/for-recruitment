using Application.Database.Models.PersonPart;

namespace Application.Database.Models.AddressPart
{
    public class Address
    {
        public Guid Id { get; set; }
        public long DivisionId { get; set; }
        public long StreetId { get; set; }

        public string BuldingNumber { get; set; } = null!;
        public string? ApartmentNumber { get; set; } = null;

        public virtual Collocation Collocation { get; set; } = null!;
        public virtual ICollection<Person> People { get; set; } = new List<Person>();
        public virtual ICollection<Depratment> Depratments { get; set; } = new List<Depratment>();
    }
}
