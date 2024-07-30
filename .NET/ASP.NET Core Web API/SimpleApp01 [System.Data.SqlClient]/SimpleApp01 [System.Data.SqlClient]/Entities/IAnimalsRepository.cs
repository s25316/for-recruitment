using SimpleApp01__System.Data.SqlClient_.Models;
using SimpleApp01__System.Data.SqlClient_.Models.DTOs;
using System.Threading.Tasks;

namespace SimpleApp01__System.Data.SqlClient_.Entities
{
    public interface IAnimalsRepository
    {
        Task<Request<IEnumerable<Animal>>> GetAnimalsAsync();
        Task<Request<AnimalDTO>> PostAnimalAsync(AnimalDTO a);
        Task<Request<AnimalDTO>> PutAnimalAsync(int IdAnimal, AnimalDTO a);
        Task<Request<AnimalDTO>> DeleteAnimalAsync(int IdAnimal);
    }
}
