using WebApplication2.DTOs;

namespace WebApplication2.DAL
{
    public interface IWarehouseService
    {
        Task<ResponseDTO> PostProduct_WarehouseAsync(PostProduct_WarehouseDTO x);
        Task<ResponseDTO> PostProduct_WarehouseByProcedureAsync(PostProduct_WarehouseDTO x);
    }
}
