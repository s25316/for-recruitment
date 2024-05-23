namespace SimpleApp06__EF__CdF_.DatabaseLayer
{
    public class Car
    {
        public int IdCar { get; set; }
        public string Make { get; set; } = null!;
        public int PropductionYear { get; set; }
        public virtual ICollection<CarPerson> CarPeople { get; set; } = new List<CarPerson>();
    }
}
