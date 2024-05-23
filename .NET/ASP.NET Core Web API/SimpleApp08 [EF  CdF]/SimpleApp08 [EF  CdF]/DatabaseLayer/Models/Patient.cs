namespace SimpleApp08__EF__CdF_.DatabaseLayer.Models
{
    public class Patient
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly Birthdate { get; set;}

        public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    }
}
