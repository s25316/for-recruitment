namespace Application.Database.Models.AddressPart
{
    public class Country
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<AdministrativeDivision> AdministrativeDivisions { get; set; }
            = new List<AdministrativeDivision>();
    }
}
