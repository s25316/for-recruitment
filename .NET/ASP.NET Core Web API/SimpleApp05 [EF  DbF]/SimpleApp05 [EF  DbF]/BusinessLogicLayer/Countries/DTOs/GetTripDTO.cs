namespace SimpleApp05__EF__DbF_.BusinessLogicLayer.Countries.DTOs
{
    public class GetTripDTO
    {
        public int IdTrip { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int MaxPeople { get; set; }
    }
}
