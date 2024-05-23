namespace SimpleApp05__EF__DbF_.BusinessLogicLayer.Countries.DTOs
{
    public class GetCountryDTO
    {
        public int IdCountry { get; set; }
        public string Name { get; set; } = null!;
        public virtual IEnumerable<GetTripDTO> Trips { get; set; } = new List<GetTripDTO>();
    }
}
