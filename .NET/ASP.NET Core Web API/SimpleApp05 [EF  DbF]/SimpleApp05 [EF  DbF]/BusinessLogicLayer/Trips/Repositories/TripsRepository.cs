using Microsoft.EntityFrameworkCore;
using SimpleApp05__EF__DbF_.BusinessLogicLayer.Trips.DTOs;
using SimpleApp05__EF__DbF_.DatabaseLayer;

namespace SimpleApp05__EF__DbF_.BusinessLogicLayer.Trips.Repositories
{
    public class TripsRepository : ITripsRepository
    {
        private readonly ApbdContext _context;
        public TripsRepository(ApbdContext context) { _context = context; }

        public async Task<IEnumerable<GetTripDTO>> GetTripsAsync() 
        { 
            return await _context.Trips.Include( t => t.IdCountries).
                Include( t => t.ClientTrips).ThenInclude( t => t.IdClientNavigation).AsNoTracking(). 
                Select ( res => new GetTripDTO() 
                { 
                    IdTrip = res.IdTrip,
                    Name = res.Name,
                    Description = res.Description,
                    DateFrom = res.DateFrom,
                    DateTo = res.DateTo,
                    MaxPeople = res.MaxPeople,
                    Clients = res.ClientTrips.Select( t => new GetTripClientDTO() 
                    { 
                        IdClient = t.IdClient,
                        FirstName = t.IdClientNavigation.FirstName,
                        LastName = t.IdClientNavigation.LastName,
                        Email = t.IdClientNavigation.Email,
                        Telephone = t.IdClientNavigation.Telephone,
                        Pesel = t.IdClientNavigation.Pesel,
                        RegisteredAt = t.RegisteredAt,
                        PaymentDate = t.PaymentDate,
                    } ).ToList(),
                    Counties = res.IdCountries.Select( c => new GetTripCountryDTO() 
                    { 
                        IdCountry = c.IdCountry,
                        Name = c.Name,
                    }).ToList(),
                }).ToListAsync();
        }

        public async Task<bool> PostTripAsync(PostTripDTO t) 
        {
            var maxId = await _context.Trips.MaxAsync( x => x.IdTrip ) + 1;
            var trip = new Trip() 
            { 
                IdTrip = maxId,
                Name = t.Name,
                Description = t.Description,
                DateFrom = t.DateFrom,
                DateTo = t.DateTo,
                MaxPeople = t.MaxPeople,
            };
            await _context.Trips.AddAsync(trip);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTripByIdAsync(int IdTrip) 
        {
            var trip = await _context.Trips.FindAsync(IdTrip);
            if (trip == null) return false;
            //1
            var listOfCountries = await _context.Trips.Where( c => c.IdTrip == IdTrip ).Include( c => c.IdCountries).ToListAsync();
            foreach ( var country in listOfCountries ) { country.IdCountries = null;  }
            //2
            var listOfClients = await _context.ClientTrips.Where(c => c.IdTrip.Equals(IdTrip)).ToListAsync();
            foreach ( var client in listOfClients ) { _context.ClientTrips.Remove( client ); }
            //3
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();

            return true;
        } 
    }
}
