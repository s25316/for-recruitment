using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp08__EF__CdF_.BusinessLogicLayer.Patient.DTOs;
using SimpleApp08__EF__CdF_.BusinessLogicLayer.Patient.Repositories;

namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Patient
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _repository;
        public PatientsController(IPatientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientsasync() 
        {
            var result = await _repository.GetPatientsAsync();
            return StatusCode(200, result);
        }

        [HttpPost]
        public async Task<IActionResult> PostPatientAsync(PatientPostDTO p) 
        { 
            await _repository.PostPatientAsync(p);
            return StatusCode(201);
        }

        [HttpDelete("{IdPatient:int}")]
        public async Task<IActionResult> DeletePatientAsync(int IdPatient) 
        { 
            var result = await _repository.DeletePatientAsync(IdPatient);
            if (result) return StatusCode(202);
            else return StatusCode(404);
        }
    }
}
