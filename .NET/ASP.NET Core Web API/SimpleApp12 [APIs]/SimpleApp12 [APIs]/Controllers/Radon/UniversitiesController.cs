using Microsoft.AspNetCore.Mvc;
using Radon.Repositories;


namespace SimpleApp12__APIs_.Controllers.Radon
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly IUniversitiesRepository _universitiesRepository;

        public UniversitiesController(IUniversitiesRepository universitiesRepository)
        {
            _universitiesRepository = universitiesRepository;
        }

        [HttpGet("{universityId:guid}/courses/")]
        public async Task<IActionResult> GetCoursesListAsync(Guid universityId, CancellationToken cancellation, [FromQuery] bool isCoreData = true)
        {
            if (isCoreData)
            {
                var resultCoreData = await _universitiesRepository.GetCoursesSourceDataAsync(universityId, cancellation);
                return Ok(resultCoreData);
            }
            var result = await _universitiesRepository.GetCoursesCustomDataAsync(universityId, cancellation);
            return Ok(result);
        }

        [HttpGet("{universityId:guid}")]
        public async Task<IActionResult> GetUniversityDataAsync(Guid universityId, CancellationToken cancellation, [FromQuery] bool isCoreData = true)
        {
            if (isCoreData)
            {
                var isCoreResult = await _universitiesRepository.GetUniversitySourceDataAsync(universityId, cancellation);
                return Ok(isCoreResult);
            }
            var isCustomResult = await _universitiesRepository.GetUniversityCustomDataAsync(universityId, cancellation);
            return Ok(isCustomResult);
        }

        [HttpGet("{universityId:guid}/branches/")]
        public async Task<IActionResult> GetBranchesListAsync(Guid universityId, CancellationToken cancellation, [FromQuery] bool isCoreData = true)
        {
            if (isCoreData)
            {
                var resultCoreData = await _universitiesRepository.GetBranchesSourceDataAsync(universityId, cancellation);
                return Ok(resultCoreData);
            }
            var result = await _universitiesRepository.GetBranchesCustomDataAsync(universityId, cancellation);
            return Ok(result);
        }


    }
}
