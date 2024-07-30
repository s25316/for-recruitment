using Microsoft.AspNetCore.Mvc;
using BialaListaVat.Repositories;
using SimpleApp12__APIs_.ValidationAttributes;

namespace SimpleApp12__APIs_.BusinessLogicLayer.WhiteListVat
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhiteListVatController : ControllerBase
    {
        private readonly IWhiteListVatRepository _whiteListVatRepository;

        public WhiteListVatController (IWhiteListVatRepository whiteListVatRepository)
        {
            _whiteListVatRepository = whiteListVatRepository;
        }

        [HttpGet("nip/{nip}")]
        public async Task<IActionResult> GetDataCompanyByNipAsync
            (
            [NipValidationAttribute] string nip, 
            CancellationToken cancellation
            ) 
        {
            //5262160983  5261008546 
            var result = await _whiteListVatRepository.GetCompanyDataByNipAsync(nip, cancellation);

            return Ok(result);
        }

        [HttpGet("regon/{regon}")]
        public async Task<IActionResult> GetDataCompanyByRegonAsync
            (
            [RegonValidationAttribute] string regon,
            CancellationToken cancellation
            )
        {
            //010816248 010778878
            var result = await _whiteListVatRepository.GetCompanyDataByRegonAsync(regon, cancellation);

            return Ok(result);
        }
    }
}
