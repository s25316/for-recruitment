using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var x = _configuration.GetSection("ConnectionStrings")["mssql"];
            return Ok(x);
        }


        [HttpGet("other")]
        public IActionResult Get2()
        {
            var x = _configuration.GetSection("Kot")["Borys"];
            return Ok(x);
        }

        [HttpGet("other2")]
        public IActionResult Get3()
        {
            var x = _configuration["Borys"];
            return Ok(x);
        }
    }
}
