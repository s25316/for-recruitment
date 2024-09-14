using Application.Repositories;
using Application.Repositories.DTOs.EmploeePart;
using Domain.Entites.DepartmentPart;
using Microsoft.AspNetCore.Mvc;

namespace SimpleApp13__MAS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsAndEmploeesController : ControllerBase
    {
        private readonly IUseCasesRepository _repository;

        public ClientsAndEmploeesController(IUseCasesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetEmploeesAsync()
        {
            var result = await _repository.GetSimpleDataEmploeesAsync();
            return Ok(result);
        }

        [HttpGet("emploee/{id}")]
        public async Task<IActionResult> GetEmploeeDataAsync(Guid id)
        {
            var result = await _repository.GetEmploeeDataAsync(id);
            return Ok(result);
        }

        [HttpPost("createEmploee")]
        public async Task<IActionResult> CreateEmploeeAsync(Guid emploeeIdWhichInserted, EmploeeDtoRequest req)
        {
            var result = await _repository.CreateEmploeeAsync(emploeeIdWhichInserted, req);
            return Ok(result);
        }

        [HttpPost("emploee/{emploeeId}/department/{departmentId}")]
        public async Task<IActionResult> EmploeeToDepartmentAsync(Guid emploeeId, Guid departmentId)

        {
            var result = await _repository.EmploeeToDepartmentAsync(emploeeId, departmentId);
            return Ok(result);
        }

        [HttpPost("setEducationHistory")]
        public async Task<IActionResult> SetEducationHistoryAsync(EducationHistoryDtoRequest req)
        {
            var result = await _repository.SetEducationHistoryAsync(req);
            return Ok(result);
        }

        [HttpPost("SetEmploymentHistory")]
        public async Task<IActionResult> SetEmploymentHistoryAsync(EmploymentHistoryDtoRequest req)

        {
            var result = await _repository.SetEmploymentHistoryAsync(req);
            return Ok(result);
        }


        [HttpPost("createDepartment")]
        public async Task<IActionResult> CreateDepartment(DepartmentDtoRequest req)

        {
            var result = await _repository.CreateDepartment(req);
            return Ok(result);
        }


    }
}
