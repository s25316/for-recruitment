using SimpleApp02__System.Data.SqlClient_.Models;
using SimpleApp02__System.Data.SqlClient_.Models.DTOs;

namespace SimpleApp02__System.Data.SqlClient_.Entities
{
    public interface IWarehousesRepository
    {
        Task<Request> PostProductWarehouseAsync(PostProductWarehouseDTO p);
        Task<Request> PostProductWarehouseProcedureAsync(PostProductWarehouseDTO p);
    }
}
