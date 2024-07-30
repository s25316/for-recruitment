namespace SimpleApp05__EF__DbF_.BusinessLogicLayer.Trips.DTOs
{
    public class GetTripClientDTO
    {
        public int IdClient { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public string Pesel { get; set; } = null!;
        public DateTime RegisteredAt { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
