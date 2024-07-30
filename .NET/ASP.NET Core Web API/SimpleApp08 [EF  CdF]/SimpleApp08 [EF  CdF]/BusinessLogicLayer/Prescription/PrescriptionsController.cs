using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp08__EF__CdF_.BusinessLogicLayer.Prescription.DTOs;
using SimpleApp08__EF__CdF_.BusinessLogicLayer.Prescription.Repositories;
using SimpleApp08__EF__CdF_.DatabaseLayer;
using System.Collections.Generic;

namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Prescription
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionRepository _repository;
        public PrescriptionsController(IPrescriptionRepository repository) { _repository = repository; }

        [HttpGet]
        public async Task<IActionResult> GetPrescriptionsAsync() 
        {
            var result = await _repository.GetPrescriptionsAsync();
            return StatusCode(200, result);
        }

        [HttpPost]
        public async Task<IActionResult> PostPrescriptionAsync(PrescriptionPostDTO p) 
        {
            try {
                await _repository.PostPrescriptionAsync(p);
            } catch (Exception ex) 
            {
                return StatusCode(404);
            }
            return StatusCode(201);
        }

        [HttpDelete("{IdPrescription:int}")]
        public async Task<IActionResult> DeletePrescriptionAsync(int IdPrescription) 
        { 
            var result = await _repository.DeletePrescriptionAsync(IdPrescription);
            if (result)  return StatusCode(202);
            else return StatusCode(404);
        }

        [HttpPost("{IdPrescription:int}")]
        public async Task<IActionResult> PostMedicamentsForPrescriptionAsync(int IdPrescription, IList<PrescriptionMedicamentPostDTO> m) 
        {
            var result = await _repository.PostMedicamentsForPrescriptionAsync(IdPrescription,m);
            if (result) return StatusCode(201);
            else return StatusCode(404);
        }
    }
}
