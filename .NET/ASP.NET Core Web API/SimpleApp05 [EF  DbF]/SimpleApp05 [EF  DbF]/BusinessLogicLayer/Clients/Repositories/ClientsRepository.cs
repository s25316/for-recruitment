using Microsoft.EntityFrameworkCore;
using SimpleApp05__EF__DbF_.BusinessLogicLayer.Clients.DTOs;
using SimpleApp05__EF__DbF_.DatabaseLayer;
using System.Globalization;

namespace SimpleApp05__EF__DbF_.BusinessLogicLayer.Clients.Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly ApbdContext _context;
        public ClientsRepository(ApbdContext context) { _context = context; }

        public async Task<IEnumerable<GetClientDTO>> GetClientsAsync() 
        {
            var result = await _context.Clients.Include( c => c.ClientTrips).ThenInclude( c => c.IdTripNavigation).
                AsNoTracking().Select ( res => new GetClientDTO() 
                { 
                    IdClient = res.IdClient,
                    FirstName = res.FirstName,
                    LastName = res.LastName,
                    Email = res.Email,
                    Telephone = res.Telephone,
                    Pesel = res.Pesel,
                    Trips = res.ClientTrips.Select( c => new GetClientTripDTO() 
                    { 
                        RegisteredAt = c.RegisteredAt,
                        PaymentDate = c.PaymentDate,
                        IdTrip = c.IdTrip,
                        Name = c.IdTripNavigation.Name,
                        Description = c.IdTripNavigation.Description,
                        DateFrom = c.IdTripNavigation.DateFrom,
                        DateTo = c.IdTripNavigation.DateTo,
                        MaxPeople = c.IdTripNavigation.MaxPeople,
                    }).ToList(),
                }).ToListAsync();
            return result;
        }
        public async Task<bool> PostClientAdync(PostClientDTO c) 
        {
            var maxId = await _context.Clients.MaxAsync( c =>  c.IdClient) + 1;
            var client = new Client() 
            { 
               IdClient = maxId,
               FirstName = c.FirstName,
               LastName = c.LastName,
               Email = c.Email,
               Telephone = c.Telephone,
               Pesel= c.Pesel,
            };
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return true; 
        }
        public async Task<bool> PostConnectionClientTripAsync(int IdClient, int IdTrip, DateTime? PaymentDate) 
        {
            var client = await _context.Clients.FindAsync(IdClient);
            var trip = await _context.Trips.FindAsync(IdTrip);

            if (client == null || trip == null) { return false; }
            var clietTrip = new ClientTrip() 
            { 
                IdClient = IdClient,
                IdTrip = IdTrip,
                PaymentDate = PaymentDate,
                RegisteredAt = DateTime.Parse(DateTime.Now.ToString(new CultureInfo("pl-PL"))),
            };
            await _context.ClientTrips.AddAsync(clietTrip);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteClientByIdAsync(int IdClient) 
        {
            var client = await _context.Clients.FindAsync(IdClient);
            if (client == null) return false;

            var listToDelete = await _context.ClientTrips.Where(ct => ct.IdClient.Equals(IdClient)).ToListAsync();
            foreach (var item in listToDelete) 
            { 
                _context.ClientTrips.Remove(item);
            }
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
