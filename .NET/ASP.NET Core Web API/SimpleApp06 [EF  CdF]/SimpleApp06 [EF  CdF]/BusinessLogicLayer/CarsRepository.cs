using Microsoft.EntityFrameworkCore;
using SimpleApp06__EF__CdF_.BusinessLogicLayer.DTOs;
using SimpleApp06__EF__CdF_.DatabaseLayer;

namespace SimpleApp06__EF__CdF_.BusinessLogicLayer
{
    public class CarsRepository : ICarsRepository
    {
        private readonly DatabaseContext _databaseContext;
        public CarsRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }


        public async Task<bool> PostCarAsync(CarPostDTO car) 
        {
            await _databaseContext.Cars.AddAsync(new Car { Make = car.Make, PropductionYear = car.PropductionYear });
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PostPearsonAsync(PersonPostDTO p) 
        {
            await _databaseContext.People.AddAsync(new Person
            { 
                Name = p.Name,
                Surname = p.Surname,
                DrivingLicence = p.DrivingLicence,
            });
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PostCarPersonAsync(int IdCar, int IdPerson,bool MainOwner) 
        {
            await _databaseContext.CarPeople.AddAsync(new CarPerson 
            {
                IdCar = IdCar,
                IdPerson = IdPerson,
                MainOwner = MainOwner
            });
            await _databaseContext.SaveChangesAsync();
            return true;
        }



        public async Task<IEnumerable<CarGetDTO>> GetCarsAsync() 
        { 
            var list = await _databaseContext.Cars.Include(c =>c.CarPeople).ThenInclude(c =>c.Person).AsNoTracking().
                Select(c => new CarGetDTO 
                { 
                    IdCar = c.IdCar,
                    Make = c.Make,
                    PropductionYear = c.PropductionYear,
                    Owners = c.CarPeople.Select(x => new CarDetailesGetDTO 
                    { 
                        IdPerson = x.IdPerson,
                        Name = x.Person.Name,
                        Surname = x.Person.Surname,
                        DrivingLicence = x.Person.DrivingLicence,
                        MainOwner = x.MainOwner,
                    }).ToList(),
                }).ToListAsync();
            return list;
        }

        public async Task<IEnumerable<PersonGetDTO>> GetPeopleAsync() 
        { 
            var list = await _databaseContext.People.Include(p => p.CarPeople).ThenInclude(p => p.Car)
                .AsNoTracking().Select(p => new PersonGetDTO 
                {
                    IdPerson = p.IdPerson,
                    Name = p.Name,
                    Surname = p.Surname,
                    DrivingLicence= p.DrivingLicence,
                    Cars = p.CarPeople.Select(x => new PersonDetailsGetDTO 
                    { 
                        IdCar = x.IdCar,
                        Make = x.Car.Make,
                        PropductionYear = x.Car.PropductionYear,
                        MainOwner = x.MainOwner
                    }).ToList(),
                }).ToListAsync();
            return list;
        }
    }
}
