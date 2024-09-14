using BialaListaVat.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace SimpleApp12__APIs_.Controllers.WhiteListVat
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhiteListVatController : ControllerBase
    {
        private readonly IWhiteListVatRepository _whiteListVatRepository;

        public WhiteListVatController(IWhiteListVatRepository whiteListVatRepository)
        {
            _whiteListVatRepository = whiteListVatRepository;
        }

        [HttpGet("nip/{nip}")]
        public async Task<IActionResult> GetDataCompanyByNipAsync
            (
            string nip,
            CancellationToken cancellation
            )
        {
            //5262160983  5261008546 
            var result = await _whiteListVatRepository.GetCompanyByNipAsync(nip, cancellation);

            return Ok(result);
        }

        [HttpGet("regon/{regon}")]
        public async Task<IActionResult> GetDataCompanyByRegonAsync
            (
             string regon,
            CancellationToken cancellation
            )
        {
            //010816248 010778878
            var result = await _whiteListVatRepository.GetCompanyByRegonAsync(regon, cancellation);

            return Ok(result);
        }
    }
}
