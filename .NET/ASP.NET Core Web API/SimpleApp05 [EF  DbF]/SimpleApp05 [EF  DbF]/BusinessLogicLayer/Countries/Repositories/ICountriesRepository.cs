using SimpleApp05__EF__DbF_.BusinessLogicLayer.Countries.DTOs;

namespace SimpleApp05__EF__DbF_.BusinessLogicLayer.Countries.Repositories
{
    public interface ICountriesRepository
    {
        Task<IEnumerable<GetCountryDTO>> GetCountriesAsync();
        Task<bool> PostCountryAsync(string CountryName);
        Task<bool> PostConnectionCountryTripAsync(int IdCountry, int IdTrip);
        Task<bool> DeleteCountryByIdAsync(int IdCountry);
    }
}
