namespace SimpleApp06__EF__CdF_.DatabaseLayer
{
    public class CarPerson
    {
        public int IdCar { get; set; }
        public int IdPerson { get; set; }
        public bool MainOwner { get; set; }

        public virtual Car Car { get; set; } = null!;
        public virtual Person Person { get; set; } = null!;
    }
}
