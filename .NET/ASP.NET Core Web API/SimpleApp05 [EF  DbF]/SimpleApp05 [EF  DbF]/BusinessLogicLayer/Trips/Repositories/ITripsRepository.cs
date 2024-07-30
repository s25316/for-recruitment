using SimpleApp05__EF__DbF_.BusinessLogicLayer.Trips.DTOs;

namespace SimpleApp05__EF__DbF_.BusinessLogicLayer.Trips.Repositories
{
    public interface ITripsRepository
    {
        Task<IEnumerable<GetTripDTO>> GetTripsAsync();
        Task<bool> PostTripAsync(PostTripDTO t);
        Task<bool> DeleteTripByIdAsync(int IdTrip);
    }
}
