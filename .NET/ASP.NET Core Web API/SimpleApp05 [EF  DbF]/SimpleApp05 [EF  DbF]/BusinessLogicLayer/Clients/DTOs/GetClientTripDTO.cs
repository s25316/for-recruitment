namespace SimpleApp05__EF__DbF_.BusinessLogicLayer.Clients.DTOs
{
    public class GetClientTripDTO
    {
        public int IdTrip { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int MaxPeople { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
