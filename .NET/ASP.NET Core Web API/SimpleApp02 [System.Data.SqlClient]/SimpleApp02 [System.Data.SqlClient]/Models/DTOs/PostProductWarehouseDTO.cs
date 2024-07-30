using System.ComponentModel.DataAnnotations;

namespace SimpleApp02__System.Data.SqlClient_.Models.DTOs
{
    public class PostProductWarehouseDTO
    {

        public required int IdProduct { get; set; }
        public required int IdWarehouse { get; set; }
        [Range(1,int.MaxValue)]
        public required int Amount { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
