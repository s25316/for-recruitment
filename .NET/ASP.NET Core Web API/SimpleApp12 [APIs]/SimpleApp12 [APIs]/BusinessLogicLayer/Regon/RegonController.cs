using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Regon.Repositories;

namespace SimpleApp12__APIs_.BusinessLogicLayer.Regon
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegonController : ControllerBase
    {
        private readonly IRegonRepository _regonRepository;

        public RegonController(IRegonRepository regonRepository) 
        { 
            _regonRepository = regonRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string nip, CancellationToken cancellation) 
        {
            try {
                var result = await _regonRepository.GetCompanyBYNIP(nip, "abcde12345abcde12345", true, cancellation);
                /*var list = result.Split("\n").Select(s => s.Trim()).ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    list[i] = $"{i} {list[i]}";
                }*/
                return Ok(result);
            } 
            catch (Exception ex) 
            {
                return StatusCode(400, ex.Message);
            }            
        }
    }
}
