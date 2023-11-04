using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public interface IAnimalsRepository
    {
        Task<IList<Animal>> GetAnimals(string orderBy);
        Task<bool> DeleteAnimalAsync(int IdAnimal);
        Task<bool> PutAnimalAsync(int IdAnimal, PutAnimalDTO a);
        Task<bool> PostAnimalAsync(PutAnimalDTO a);
    }
}
