using SimpleApp06__EF__CdF_.BusinessLogicLayer.DTOs;

namespace SimpleApp06__EF__CdF_.BusinessLogicLayer
{
    public interface ICarsRepository
    {
        Task<bool> PostCarAsync(CarPostDTO car);
        Task<bool> PostPearsonAsync(PersonPostDTO p);
        Task<bool> PostCarPersonAsync(int IdCar, int IdPerson, bool MainOwner);


        Task<IEnumerable<CarGetDTO>> GetCarsAsync();
        Task<IEnumerable<PersonGetDTO>> GetPeopleAsync();
    }
}
