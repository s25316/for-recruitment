using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class AnimalsRepository : IAnimalsRepository
    {
        private IConfiguration _con;
        public AnimalsRepository(IConfiguration con) 
        {
            _con = con;
        }
        public async Task<IList<Animal>> GetAnimals( string orderBy) 
        {
            List<Animal> animals = new  ();

            await using (SqlConnection con = new SqlConnection(_con.GetConnectionString("DBString")))
            {
                await using SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "SELECT * FROM Animal";


                await con.OpenAsync();
                await using SqlDataReader gotAnimals = await com.ExecuteReaderAsync();
                while (await gotAnimals.ReadAsync())
                {
                    Animal a = new()
                    {
                        IdAnimal = int.Parse(gotAnimals["IdAnimal"].ToString()),
                        Name = gotAnimals["Name"].ToString(),
                        Description = gotAnimals["Description"].ToString(),
                        Category = gotAnimals["Category"].ToString(),
                        Area = gotAnimals["Area"].ToString()
                    };
                    animals.Add(a);
                };

            };
            return animals;
        }

        public async Task<bool> PostAnimalAsync(PutAnimalDTO a)
        {
            int rows = 0;
            await using (SqlConnection con = new SqlConnection(_con.GetConnectionString("DBString"))) 
            { 
                await using SqlCommand com = new SqlCommand();
                // await using SqlCommand sqlCommand = new( sqlQuery, con); v2
                com.Connection = con;
                com.CommandText = $"INSERT INTO Animal ( Name , Description , Category, Area ) VALUES ( '{a.Name}', '{a.Description}','{a.Category}', '{a.Area}');";

                await con.OpenAsync();

                rows = await com.ExecuteNonQueryAsync();
            };
            return rows > 0;
        }
        public async Task<bool> PutAnimalAsync(int IdAnimal, PutAnimalDTO a)
        {
            int rows = 0;
            await using (SqlConnection con = new SqlConnection(_con.GetConnectionString("DBString")))
            {
                await using SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = $"UPDATE Animal SET Name = '{a.Name}', Description = '{a.Description}', Category = '{a.Category}', Area = '{a.Area}' WHERE IdAnimal = {IdAnimal}";

                await con.OpenAsync();

                rows = await com.ExecuteNonQueryAsync();
            };
            return rows > 0;
        }
        public async Task<bool> DeleteAnimalAsync(int IdAnimal)
        {
            int rows = 0;
            await using (SqlConnection con = new SqlConnection( _con.GetConnectionString("DBString"))) 
            {
                await using SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = $"DELETE FROM Animal WHERE IdAnimal = {IdAnimal}";

                await con.OpenAsync();

                rows = await com.ExecuteNonQueryAsync();
            };
            return rows > 0;
        }
    }
}
