using Microsoft.AspNetCore.Mvc;
using Regon.AggregatesAndEntities.Responses;
using Regon.Repositories;

namespace SimpleApp12__APIs_.Controllers.Regon
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegonController : ControllerBase
    {
        private readonly IRegonRepository _regonRepository;
        private readonly string _key = "";

        public RegonController(IRegonRepository regonRepository)
        {
            _regonRepository = regonRepository;
        }

        [HttpGet("nip/{nip}")]
        public async Task<IActionResult> Index(string nip, CancellationToken cancellation, [FromQuery] bool isCustomized = true)
        {

            if (!isCustomized)
            {
                var resultSource = await _regonRepository.GetCompanyByNipSourceDataAsync(nip, _key, cancellation, true);
                if (resultSource.Problem == EnumProblemTypes.UserProblem)
                {
                    return StatusCode(404, resultSource.MessageForUser);
                }
                if (resultSource.Problem == EnumProblemTypes.AppProblem)
                {
                    Console.WriteLine(resultSource.MessageForAdmin);
                    return StatusCode(500, resultSource.MessageForUser);
                }
                return Ok(resultSource.Item);
            }
            var result = await _regonRepository.GetCompanyByNipCustomDataAsync(nip, _key, cancellation, true);
            return Ok(result);
        }


        [HttpGet("regon/{regon}")]
        public async Task<IActionResult> Index2(string regon, CancellationToken cancellation, [FromQuery] bool isCustomized = true)
        {

            if (!isCustomized)
            {
                var resultSource = await _regonRepository.GetCompanyByRegonSourceDataAsync(regon, _key, cancellation, true);
                if (resultSource.Problem == EnumProblemTypes.UserProblem)
                {
                    return StatusCode(404, resultSource.MessageForUser);
                }
                if (resultSource.Problem == EnumProblemTypes.AppProblem)
                {
                    Console.WriteLine(resultSource.MessageForAdmin);
                    return StatusCode(500, resultSource.MessageForUser);
                }
                return Ok(resultSource.Item);
            }
            var result = await _regonRepository.GetCompanyByRegonCustomDataAsync(regon, _key, cancellation, true);
            return Ok(result);
        }
    }
}
