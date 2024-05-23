using SimpleApp02__System.Data.SqlClient_.Models;
using SimpleApp02__System.Data.SqlClient_.Models.DTOs;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SimpleApp02__System.Data.SqlClient_.Entities
{
    public class WarehousesRepository : IWarehousesRepository
    {
        private readonly string _connectionString;
        public WarehousesRepository(IConfiguration conf) 
        { 
            _connectionString = conf.GetConnectionString("DBString");
        }


        
        public async Task<Request> PostProductWarehouseAsync(PostProductWarehouseDTO p) 
        {
            
            bool isExistIdProduct = await IsExistIdProductAsync(p.IdProduct);
            bool isExistIdWarehouse = await IsExistIdWarehouseAsync(p.IdWarehouse);
            if (!isExistIdProduct || !isExistIdWarehouse) 
            {
                return new Request() 
                { 
                    Code = 404,
                    Message = $"{(!isExistIdProduct ? "By This IdProduct Product don`t exist" : "")} " +
                    $"{(!isExistIdWarehouse ? "By This IdWarehouse Warehouse don`t exist" : "")}",
                };
            }
            
            int idOrder = await GetIdOrderAsync(p);
            if (idOrder < 0) 
            {
                return new Request()
                {
                    Code = 404,
                    Message = "By This Data Order don`t exist",
                };
            }
            bool hasCompletedOrder = (await GetIdProductWarehouseAsync(idOrder)) >= 0;
            if (hasCompletedOrder) 
            {
                return new Request()
                {
                    Code = 404,
                    Message = "By This Order completed",
                };
            }
            bool hasUpdated = await UpdateFullfilledAtOrderAsync(idOrder);
            bool hasAdd = await PostProductWarehouseAsync(p,idOrder);
            int idRealization = await GetIdProductWarehouseAsync(idOrder);

            
            return new Request()
            {
                Code = 200,
                Message = $"Realization ID of this Order: {idRealization}",
            };
        }
        //1
        private async Task<bool> IsExistIdProductAsync(int IdProduct) 
        {
            await using (SqlConnection con = new SqlConnection(_connectionString)) 
            { 
                using SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT IdProduct from Product where IdProduct = @IdProduct";
                cmd.Parameters.AddWithValue("@IdProduct", IdProduct);

                try 
                {
                    await con.OpenAsync();
                    await using var reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync()) 
                    { 
                        return true;
                    }
                }
                catch (SqlException ex) { PrintSqlExceptionsErrors(ex); }
            }
            return false;
        }

        private async Task<bool> IsExistIdWarehouseAsync(int IdWarehouse)
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT IdWarehouse from Warehouse where IdWarehouse = @IdWarehouse";
                cmd.Parameters.AddWithValue("@IdWarehouse", IdWarehouse);

                try
                {
                    await con.OpenAsync();
                    await using var reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        return true;
                    }
                }
                catch (SqlException ex) { PrintSqlExceptionsErrors(ex); }
            }
            return false;
        }
        //2
        private async Task<int> GetIdOrderAsync(PostProductWarehouseDTO p)
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT IdOrder, CreatedAt from \"Order\" where Amount = @Amount AND  IdProduct = @IdProduct AND CreatedAt < @CreatedAt ";
                cmd.Parameters.AddWithValue("@Amount", p.Amount);
                cmd.Parameters.AddWithValue("@IdProduct", p.IdProduct);
                cmd.Parameters.AddWithValue("@CreatedAt", p.CreatedAt.ToString("s"));
                try
                {
                    await con.OpenAsync();
                    await using var reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        return (int)reader["IdOrder"];
                    }
                }
                catch (SqlException ex) { PrintSqlExceptionsErrors(ex); }
            }
            return -1;
        }
        //3
        private async Task<int> GetIdProductWarehouseAsync(int IdOrder) 
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT IdProductWarehouse from Product_Warehouse where IdOrder = @IdOrder";
                cmd.Parameters.AddWithValue("@IdOrder", IdOrder);
                try
                {
                    await con.OpenAsync();
                    await using var reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        return (int)reader["IdProductWarehouse"];
                    }
                }
                catch (SqlException ex) { PrintSqlExceptionsErrors(ex); }
            }
            return -1;
        }
        //4
        private async Task<bool> UpdateFullfilledAtOrderAsync(int IdOrder) 
        {
            int result = 0;
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE \"ORDER\" SET FulfilledAt = GETDATE() Where IdOrder = @IdOrder";
                cmd.Parameters.AddWithValue("@IdOrder", IdOrder);
                try
                {
                    await con.OpenAsync();
                    result= await cmd.ExecuteNonQueryAsync();                    
                }
                catch (SqlException ex) { PrintSqlExceptionsErrors(ex); }
            }
            return result > 0 ;
        }
        //5
        private async Task<bool> PostProductWarehouseAsync(PostProductWarehouseDTO p,int IdOrder)
        {
            int result = 0;
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Product_Warehouse (IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) " +
                "VALUES (@IdWarehouse, @IdProduct, @IdOrder, @Amount, (SELECT Price FROM Product WHERE  IdProduct = @IdProduct2) * @Amount2, GETDATE() )";
                cmd.Parameters.AddWithValue("@IdWarehouse", p.IdWarehouse);
                cmd.Parameters.AddWithValue("@IdProduct", p.IdProduct);
                cmd.Parameters.AddWithValue("@IdProduct2", p.IdProduct);
                cmd.Parameters.AddWithValue("@IdOrder", IdOrder);
                cmd.Parameters.AddWithValue("@Amount", p.Amount);
                cmd.Parameters.AddWithValue("@Amount2", p.Amount);
                try
                {
                    await con.OpenAsync();
                    result = await cmd.ExecuteNonQueryAsync();
                }
                catch (SqlException ex) { PrintSqlExceptionsErrors(ex); }
            }
            return result > 0;
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

        //1-5 Procedure
        public async Task<Request> PostProductWarehouseProcedureAsync(PostProductWarehouseDTO p) 
        {
            int result = 0;
            var errorMessage =new StringBuilder();
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                //v2 SqlCommand cmd = new SqlCommand( "AddProductToWarehouse", con);
                using SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "AddProductToWarehouse";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdProduct", p.IdProduct);
                cmd.Parameters.AddWithValue("@IdWarehouse", p.IdWarehouse);
                cmd.Parameters.AddWithValue("@Amount", p.Amount);
                cmd.Parameters.AddWithValue("@CreatedAt", p.CreatedAt.ToString("s"));
                try
                {
                    await con.OpenAsync();
                    result = await cmd.ExecuteNonQueryAsync();
                }
                catch (SqlException ex) 
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessage.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "Error Number: " + ex.Errors[i].Number + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }
                }
            }
            return new Request()
            { 
                Code = ( result > 0 ? 200 : 404 ),
                Message = ( result > 0 ? "Order Realizated" :  errorMessage.ToString() ),                
            };
        }
    }
}
