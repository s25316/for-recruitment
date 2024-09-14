namespace Application.Repositories.DTOs.PersonCreateProfile
{
    public class AdressDtoRequest
    {
        public long DivisionId { get; set; }
        public long StreetId { get; set; }
        public string BuildingNumber { get; set; } = null!;
        public string? ApartmentNumber { get; set; } = null;
    }
}
