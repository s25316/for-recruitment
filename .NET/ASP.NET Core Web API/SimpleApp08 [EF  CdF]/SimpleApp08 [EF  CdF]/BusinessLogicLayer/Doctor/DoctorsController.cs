using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SimpleApp08__EF__CdF_.BusinessLogicLayer.Doctor.DTOs;
using SimpleApp08__EF__CdF_.BusinessLogicLayer.Doctor.Repositories;

namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Doctor
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepository _repository;
        public DoctorsController(IDoctorRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetDoctorsAsync() 
        {
            var result = await _repository.GetDoctorsAsync();
            return StatusCode(200, result);
        }

        [HttpPost]
        public async Task<IActionResult> PostDoctorAsync(DoctorPostDTO d) 
        { 
            await _repository.PostDoctorAsync(d);
            return StatusCode(201);
        }

        [HttpDelete("{IdDoctor:int}")]
        public async Task<IActionResult> DeleteDoctorAsync(int IdDoctor) 
        {
            var result = await _repository.DeleteDoctorAsync(IdDoctor);
            if (result) return StatusCode(202);
            else return StatusCode(404);
        }
    }
}
