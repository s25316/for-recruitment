using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DAL;
using WebApplication2.DTOs;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Warehouses2Controller : ControllerBase
    {
        private readonly IWarehouseService _war;

        public Warehouses2Controller(IWarehouseService war)
        {
            _war = war;
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct_WarehouseAsync(PostProduct_WarehouseDTO x)
        {
            var result = await _war.PostProduct_WarehouseByProcedureAsync(x);
            return (result.Code == 200) ? Ok(result.Massage) : NotFound(result.Massage);
        }
    }
}
