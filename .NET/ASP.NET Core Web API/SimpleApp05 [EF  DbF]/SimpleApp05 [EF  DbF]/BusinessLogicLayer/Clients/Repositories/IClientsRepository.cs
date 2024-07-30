using SimpleApp05__EF__DbF_.BusinessLogicLayer.Clients.DTOs;

namespace SimpleApp05__EF__DbF_.BusinessLogicLayer.Clients.Repositories
{
    public interface IClientsRepository
    {
        Task<IEnumerable<GetClientDTO>> GetClientsAsync();
        Task<bool> PostClientAdync(PostClientDTO c);
        Task<bool> PostConnectionClientTripAsync(int IdClient, int IdTrip, DateTime? PaymentDate);
        Task<bool> DeleteClientByIdAsync(int IdClient);
    }
}
