namespace Application.Database.Models.AddressPart
{
    public class Street
    {
        public long Id { get; set; }
        public string? IdSource { get; set; } = null;
        public string Name1 { get; set; } = null!;
        public string? Name2 { get; set; } = null;

        public long? TypeId { get; set; } = null;
        public virtual AdministrativeType? Type { get; set; } = null;
        public virtual ICollection<Collocation> Collocations { get; set; } = new List<Collocation>();
    }
}
