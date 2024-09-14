namespace Application.Database.Models.AddressPart
{
    public class AdministrativeDivision
    {
        public long Id { get; set; }
        public long? ParentId { get; set; } = null;
        public string? SourceId { get; set; } = null;
        public string Name { get; set; } = null!;

        public long TypeId { get; set; }
        public virtual AdministrativeType Type { get; set; } = null!;

        public long CountryId { get; set; }
        public virtual Country Country { get; set; } = null!;

        public virtual ICollection<Collocation> Collocations { get; set; } = new List<Collocation>();
    }
}
