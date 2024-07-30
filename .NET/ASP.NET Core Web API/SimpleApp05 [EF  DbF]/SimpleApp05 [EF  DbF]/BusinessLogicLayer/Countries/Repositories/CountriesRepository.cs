using Microsoft.EntityFrameworkCore;
using SimpleApp05__EF__DbF_.BusinessLogicLayer.Countries.DTOs;
using SimpleApp05__EF__DbF_.DatabaseLayer;
using System.Runtime.CompilerServices;

namespace SimpleApp05__EF__DbF_.BusinessLogicLayer.Countries.Repositories
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly ApbdContext _context;
        public CountriesRepository (ApbdContext context) { _context = context; }

        public async Task<IEnumerable<GetCountryDTO>> GetCountriesAsync() 
        {
            var result = await _context.Countries.Include(c => c.IdTrips).AsNoTracking().
                Select( res => new GetCountryDTO() 
                { 
                    IdCountry = res.IdCountry,
                    Name = res.Name,
                    Trips = res.IdTrips.Select(x => new GetTripDTO() 
                    { 
                        IdTrip = x.IdTrip,
                        Name = x.Name,
                        Description = x.Description,
                        DateFrom = x.DateFrom,
                        DateTo = x.DateTo,
                        MaxPeople = x.MaxPeople,
                    }).ToList(),
                }).ToListAsync();
            return result;
        }

        public async Task<bool> PostCountryAsync(string CountryName)
        {
            var maxId = await _context.Countries.MaxAsync( x => x.IdCountry) + 1;
            var country = new Country() 
            { 
                IdCountry = maxId,
                Name = CountryName  
            };
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PostConnectionCountryTripAsync(int IdCountry, int IdTrip)
        {
            var country = await _context.Countries.FindAsync(IdCountry);
            var trip = await _context.Trips.FindAsync(IdTrip);
            if (country == null || trip == null) return false;

            country.IdTrips.Add( trip);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCountryByIdAsync(int IdCountry) 
        {
            var country = await _context.Countries.FindAsync(IdCountry);
            if (country == null) return false;

            var list = await _context.Countries.Where(c => c.IdCountry.Equals(IdCountry)).Include(c => c.IdTrips).ToListAsync();
            foreach ( var x  in list ) 
            {
                x.IdTrips = null;
            }
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
