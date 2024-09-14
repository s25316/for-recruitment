namespace Application.Database.Models.AddressPart
{
    public class Collocation
    {
        public long DivisionId { get; set; }
        public long StreetId { get; set; }

        public virtual AdministrativeDivision AdministrativeDivision { get; set; } = null!;
        public virtual Street Street { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
