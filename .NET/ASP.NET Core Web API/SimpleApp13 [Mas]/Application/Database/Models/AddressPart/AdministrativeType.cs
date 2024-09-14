namespace Application.Database.Models.AddressPart
{
    public class AdministrativeType
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long Depth { get; set; }

        public virtual ICollection<AdministrativeDivision> AdministrativeDivisions { get; set; } = new List<AdministrativeDivision>();
        public virtual ICollection<Street> Streets { get; set; } = new List<Street>();
    }
}
