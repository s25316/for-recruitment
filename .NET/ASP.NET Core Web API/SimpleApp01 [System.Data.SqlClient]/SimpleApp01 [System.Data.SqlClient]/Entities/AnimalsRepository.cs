using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using SimpleApp01__System.Data.SqlClient_.Models;
using SimpleApp01__System.Data.SqlClient_.Models.DTOs;
using System.Text;

namespace SimpleApp01__System.Data.SqlClient_.Entities
{
    public class AnimalsRepository : IAnimalsRepository
    {
        //Comments About Previous Project
        /*
         * E1       Read DateOnly from DB
         * cmd.CommandText = "SELECT p.id, BirthDate, Name, Surname FROM  Pearson p left join Employee e on p.Id = e.Id  where e.Id is null ";
         * pId = int.Parse(reader["Id"].ToString());
         * pBirthDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["BirthDate"].ToString()) );
         * 
         * E2       Write DateOnly And Null to DB
         * cmd.CommandText = "insert into Employee (Id, EmploymentDate , Description,  Boss_Id ) values (@Id, @EmploymentDate , @Description,  @Boss_Id );";
         *       cmd.Parameters.AddWithValue("@Id", base.Id);
         *       cmd.Parameters.AddWithValue("@EmploymentDate", this.EmploymentDate.ToString("yyyy-MM-dd"));
         *       cmd.Parameters.AddWithValue("@Description", (this.Description==null) ? DBNull.Value : this.Description);
         *       cmd.Parameters.AddWithValue("@Boss_Id", (this.Boss_Id == null) ? DBNull.Value: this.Boss_Id);
         * 
         * E3       Get null value from DB
         * pBoss_Id = (reader["Boss_Id"].ToString().IsNullOrEmpty()) ? null : int.Parse(reader["Boss_Id"].ToString());
         * 
         * E4       Other Option AddWithValue 
         * cmd.Parameters.Add(new SqlParameter("@BirthDate", BirthDate.ToString("yyyy-MM-dd")));
         */
        private readonly string _stringConnection;

        public AnimalsRepository(IConfiguration conf) 
        {
            _stringConnection = conf.GetConnectionString("DBString");
        }

        public async Task<Request<IEnumerable<Animal>>> GetAnimalsAsync() 
        { 
            var animals = new List<Animal>();
            await using ( SqlConnection con = new SqlConnection(_stringConnection) ) 
            {
                //If we using Order by use Concatenation: ""+""
                using SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal";

                try
                { 
                    await con.OpenAsync();
                    await using var reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync()) 
                    {
                        animals.Add( new Animal() 
                        {
                            IdAnimal = (int)reader["IdAnimal"],
                            Name = (string)reader["name"],
                            Description = (reader["Description"].ToString().IsNullOrEmpty()) ? null : reader["Description"].ToString(),
                            Category = (string)reader["Category"],
                            Area = (string)reader["Area"],
                        });
                    }
                }
                catch (SqlException ex) 
                { 
                    PrintSqlExceptionsErrors(ex);
                    return new Request<IEnumerable<Animal>>()
                    {
                        Code = 500,
                        HasValue = false,
                        Value = null
                    };
                }
            }

            if (animals.Count == 0) 
            { 
                return new Request<IEnumerable<Animal>>()
                {
                    Code = 204,
                    HasValue = false,
                    Value = null
                };
            }

            return new Request<IEnumerable<Animal>>() 
            { 
                Code = 200,
                HasValue = true,
                Value = animals
            };
        }
        public async Task<Request<AnimalDTO>> PostAnimalAsync (AnimalDTO a) 
        { 
            int result = 0;
            await using (SqlConnection con = new SqlConnection(_stringConnection)) 
            { 
                using SqlCommand cmd = new ();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Animal (Name, Description, Category, Area) VALUES ( @Name, @Description, @Category, @Area)";
                cmd.Parameters.AddWithValue("@Name", a.Name);
                cmd.Parameters.AddWithValue("@Description", (a.Description==null)? DBNull.Value : a.Description);
                cmd.Parameters.AddWithValue("@Category", a.Category);
                cmd.Parameters.AddWithValue("@Area", a.Area);

                try 
                { 
                    await con.OpenAsync ();
                    result = await cmd.ExecuteNonQueryAsync ();
                } catch (SqlException ex) 
                {
                    PrintSqlExceptionsErrors(ex);
                    return new Request<AnimalDTO>() 
                    { 
                        Code = 500,
                        HasValue = false,
                    };
                }
            }

            if (result == 0) 
            {
                return new Request<AnimalDTO>()
                {
                    Code = 204,
                    HasValue = false,
                };
            }
            return new Request<AnimalDTO>() 
            { 
             Code=201,
             HasValue = false,
            };
        }

        public async Task<Request<AnimalDTO>> PutAnimalAsync(int IdAnimal, AnimalDTO a)
        {
            int result = 0;
            await using (SqlConnection con = new SqlConnection(_stringConnection))
            {
                using SqlCommand cmd = new();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Animal SET  Name = @Name , Description = @Description , Category = @Category , Area = @Area WHERE IdAnimal = @IdAnimal";
                cmd.Parameters.AddWithValue("@IdAnimal", IdAnimal);
                cmd.Parameters.AddWithValue("@Name", a.Name);
                cmd.Parameters.AddWithValue("@Description", (a.Description == null) ? DBNull.Value : a.Description);
                cmd.Parameters.AddWithValue("@Category", a.Category);
                cmd.Parameters.AddWithValue("@Area", a.Area);

                try
                {
                    await con.OpenAsync();
                    result = await cmd.ExecuteNonQueryAsync();
                }
                catch (SqlException ex)
                {
                    PrintSqlExceptionsErrors(ex);
                    return new Request<AnimalDTO>()
                    {
                        Code = 500,
                        HasValue = false,
                    };
                }
            }

            if (result == 0)
            {
                return new Request<AnimalDTO>()
                {
                    Code = 204,
                    HasValue = false,
                };
            }
            return new Request<AnimalDTO>()
            {
                Code = 202,
                HasValue = false,
            };
        }

        public async Task<Request<AnimalDTO>> DeleteAnimalAsync(int IdAnimal)
        {
            int result = 0;
            await using (SqlConnection con = new SqlConnection(_stringConnection))
            {
                using SqlCommand cmd = new();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";
                cmd.Parameters.AddWithValue("@IdAnimal", IdAnimal);

                try
                {
                    await con.OpenAsync();
                    result = await cmd.ExecuteNonQueryAsync();
                }
                catch (SqlException ex)
                {
                    PrintSqlExceptionsErrors(ex);
                    return new Request<AnimalDTO>()
                    {
                        Code = 500,
                        HasValue = false,
                    };
                }
            }

            if (result == 0)
            {
                return new Request<AnimalDTO>()
                {
                    Code = 204,
                    HasValue = false,
                };
            }
            return new Request<AnimalDTO>()
            {
                Code = 202,
                HasValue = false,
            };
        }

        /*Exception*/
        protected static void PrintSqlExceptionsErrors(SqlException ex)
        {
            /* https://learn.microsoft.com/pl-pl/dotnet/api/system.data.sqlclient.sqlexception?view=dotnet-plat-ext-8.0
                    */
            StringBuilder errorMessages = new StringBuilder();
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                errorMessages.Append("Index #" + i + "\n" +
                    "Message: " + ex.Errors[i].Message + "\n" +
                    "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                    "Source: " + ex.Errors[i].Source + "\n" +
                    "Procedure: " + ex.Errors[i].Procedure + "\n");
            }
            Console.WriteLine(errorMessages.ToString());
        }

    }
}
