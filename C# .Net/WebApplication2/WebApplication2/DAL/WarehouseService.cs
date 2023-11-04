using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WebApplication2.DTOs;

namespace WebApplication2.DAL
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IConfiguration _con;
        public WarehouseService(IConfiguration con) 
        {
            this._con = con;
        }
        public async Task<ResponseDTO> PostProduct_WarehouseAsync(PostProduct_WarehouseDTO x) 
        {
            string massage = "";
            var isExistProductId = await IsExistProductIdAsync(x.IdProduct);
            var isExistWarehouseAsync = await IsExistWarehouseAsync(x.IdWarehouse);
            if (isExistProductId == false && isExistWarehouseAsync == false)
                return new ResponseDTO() 
                {
                    Code = 404,
                    Massage = $"{((isExistProductId == false) ? "Not exist ProductId" : "")} {((isExistWarehouseAsync == false) ? "Not exist Warehouse" : "")}"
                };
            
            var idOrder = await GetIdOrderFromOrderIfExistAsync(x.IdProduct, x.Amount, x.CreatedAt );
            if (idOrder == -1)
                return new ResponseDTO() 
                {
                    Code= 404,
                    Massage = "Not exist Order"
                };

            var idProduct_Warehouse = await GetIdIfExistInProduct_WarehouseAsync(idOrder);
            if (idProduct_Warehouse != -1)
                return new ResponseDTO() 
                {
                    Code = 404,
                    Massage = "The order has already been completed"
                };

            var updatedFullfilledAtInOrderasync = await UpdateFullfilledAtInOrderasync(idOrder);
            var insertIntoProduct_WarehouseAsync = await InsertIntoProduct_WarehouseAsync(x, idOrder);
            var idProduct_WarehouseInserted = await GetIdIfExistInProduct_WarehouseAsync(idOrder);
            return new ResponseDTO() 
            { 
                Code = 200,
                Massage = "The order is completed"
            };  
            
        }
        private async Task<bool> IsExistProductIdAsync(int IdProduct) 
        {
            await using (SqlConnection con = new SqlConnection(_con.GetConnectionString("DBString"))) 
            { 
                await using SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM PRODUCT WHERE IdProduct = @IdProduct";
                cmd.Parameters.AddWithValue("@IdProduct", IdProduct);

                await con.OpenAsync();
                await using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    return true;
                }
            };
            return false;
        }
        private async Task <bool> IsExistWarehouseAsync(int IdWarehouse) 
        {
            await using (SqlConnection con = new SqlConnection(_con.GetConnectionString("DBString"))) 
            { 
                await using SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"SELECT * FROM Warehouse WHERE IdWarehouse = @IdWarehouse";
                cmd.Parameters.AddWithValue ("@IdWarehouse", IdWarehouse);

                await con.OpenAsync();
                await using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    return true;
                }
            };
            return false;
        }
        private async Task<int> GetIdOrderFromOrderIfExistAsync(int IdProduct, int Amount, DateTime CreatedAt) 
        { 
            await using (SqlConnection con = new SqlConnection( _con.GetConnectionString("DBString"))) 
            { 
                await using SqlCommand sql = new SqlCommand();
                sql.Connection = con;
                sql.CommandText = "SELECT IdOrder, CreatedAt FROM \"Order\" WHERE IdProduct = @IdProduct AND Amount = @Amount ";
                sql.Parameters.AddWithValue("@IdProduct", IdProduct);
                sql.Parameters.AddWithValue("@Amount", Amount);
                //sql.Parameters.AddWithValue("@CreatedAt", CreatedAt.ToString()); //and CreatedAt < CONVERT(DATETIME,'@CreatedAt')

                await con.OpenAsync();

                await using SqlDataReader reader = await sql.ExecuteReaderAsync();
                while (await reader.ReadAsync()) 
                {
                    DateTime dateTime = DateTime.Parse(reader["CreatedAt"].ToString());
                    if (dateTime <= CreatedAt)
                        return int.Parse(reader["IdOrder"].ToString()) ;
                }
            };
            return -1;
        }
        private async Task<int> GetIdIfExistInProduct_WarehouseAsync(int IdOrder) 
        {
            int result = -1;
            await using (SqlConnection con = new SqlConnection( _con.GetConnectionString("DBString"))) 
            { 
                await using SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "SELECT * FROM Product_Warehouse WHERE IdOrder = @IdOrder";
                com.Parameters.AddWithValue("@IdOrder", IdOrder);

                await con.OpenAsync();
                await using SqlDataReader reader = await com.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    return int.Parse(reader["IdProductWarehouse"].ToString());
                }
            }
            return result;
        }
        private async Task<bool> UpdateFullfilledAtInOrderasync(int IdOrder)
        {
            int result = 0;
            await using (SqlConnection con = new SqlConnection(_con.GetConnectionString("DBString")))
            {
                await using SqlCommand sql = new SqlCommand();
                sql.Connection = con;
                sql.CommandText = "UPDATE \"Order\" SET FulfilledAt = GETDATE() WHERE IdOrder = @IdOrder ";
                sql.Parameters.AddWithValue("@IdOrder", IdOrder);

                await con.OpenAsync();

                result =  await sql.ExecuteNonQueryAsync();
            };
            return result > 0;
        }
        private async Task<bool> InsertIntoProduct_WarehouseAsync(PostProduct_WarehouseDTO x, int IdOrder)
        {
            int result = 0;
            await using (SqlConnection con = new SqlConnection(_con.GetConnectionString("DBString")))
            {
                await using SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText =              
                "INSERT INTO Product_Warehouse (IdWarehouse , IdProduct , IdOrder, Amount, Price, CreatedAt  )"+
                "VALUES( @IdWarehouse, @IdProduct, @IdOrder,@Amount, (SELECT PRICE FROM PRODUCT WHERE IdProduct = @IdProduct2) , GETDATE())";
                com.Parameters.AddWithValue("@IdWarehouse", x.IdWarehouse);
                com.Parameters.AddWithValue("@IdProduct", x.IdProduct);
                com.Parameters.AddWithValue("@Amount", x.Amount);
                com.Parameters.AddWithValue("@IdProduct2", x.IdProduct);
                com.Parameters.AddWithValue("@IdOrder", IdOrder);

                await con.OpenAsync();

                result = await com.ExecuteNonQueryAsync();
            }
            return result > 0; 
        }
        //======================================================================================================
        //https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlexception.procedure?view=dotnet-plat-ext-7.0
        //https://stackoverflow.com/questions/7542517/call-a-stored-procedure-with-parameter-in-c-sharp
        public async Task<ResponseDTO> PostProduct_WarehouseByProcedureAsync(PostProduct_WarehouseDTO x) 
        {
            int result = -1;
            StringBuilder errorMessages = new StringBuilder();


            await using (SqlConnection con = new SqlConnection(_con.GetConnectionString("DBString")))
            {
                await using (SqlCommand sql = new SqlCommand("AddProductToWarehouse", con)) 
                {
                    sql.CommandType = CommandType.StoredProcedure;

                    //sql.CommandText = "EXECUTE AddProductToWarehouse @IdProduct, @IdWarehouse, @Amount, @CreatedAt ";
                    sql.Parameters.AddWithValue("@IdProduct", x.IdProduct);
                    sql.Parameters.AddWithValue("@IdWarehouse", x.IdWarehouse);
                    sql.Parameters.AddWithValue("@Amount", x.Amount);
                    sql.Parameters.AddWithValue("@CreatedAt", x.CreatedAt.ToString("s"));


                    try
                    {
                        await con.OpenAsync();
                        result = sql.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        for (int i = 0; i < ex.Errors.Count; i++)
                        {
                            errorMessages.Append("Index #" + i + "\n" +
                                "Message: " + ex.Errors[i].Message + "\n" +
                                "Error Number: " + ex.Errors[i].Number + "\n" +
                                "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                                "Source: " + ex.Errors[i].Source + "\n" +
                                "Procedure: " + ex.Errors[i].Procedure + "\n");
                        }
                        //Console.WriteLine(errorMessages.ToString());
                    }
                };
            };
            return new ResponseDTO() 
            { 
                Code = (result >0 ) ? 200 : 404,
                Massage = (result > 0) ? "The order is completed" : errorMessages.ToString()
            };
            //return new ResponseDTO();
        }


    }
}

/*
 {
  "idProduct": 1,
  "idWarehouse": 1,
  "amount": 125,
  "createdAt": "2023-11-05T11:13:36.663Z"
}
 
 */
