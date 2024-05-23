namespace SimpleApp06__EF__CdF_.DatabaseLayer
{
    public class Person
    {
        public int IdPerson { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? DrivingLicence { get; set; } = null;
        public virtual ICollection<CarPerson> CarPeople {  get; set; } = new List<CarPerson>(); 
    }
}
