using Microsoft.AspNetCore.Mvc;
using Radon.Repositories;


namespace SimpleApp12__APIs_.BusinessLogicLayer.Radon
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
        public async Task<IActionResult> GetCoursesListAsync(Guid universityId, CancellationToken cancellation) 
        { 
            var result = await _universitiesRepository.GetCoursesListAsync(universityId, cancellation);
            return Ok(result);
        }

        [HttpGet("{universityId:guid}")]
        public async Task<IActionResult> GetUniversityDataAsync(Guid universityId, CancellationToken cancellation) 
        { 
            var result = await _universitiesRepository.GetUniversityDataAsync(universityId, cancellation);
            return Ok(result);
        }
    }
}
