using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp02__System.Data.SqlClient_.Entities;
using SimpleApp02__System.Data.SqlClient_.Models.DTOs;

namespace SimpleApp02__System.Data.SqlClient_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private IWarehousesRepository _repository;

        public WarehousesController(IWarehousesRepository repository) 
        { 
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> PostProductWarehouseAsync(PostProductWarehouseDTO p) 
        { 
            var result = await _repository.PostProductWarehouseAsync(p);
            return StatusCode(result.Code, result.Message);
        }

        [HttpPost("/Procedure")]
        public async Task<IActionResult> PostProductWarehouseProcedureAsync(PostProductWarehouseDTO p)
        {
            var result = await _repository.PostProductWarehouseProcedureAsync(p);
            return StatusCode(result.Code, result.Message);
        }
    }
}
