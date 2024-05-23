using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp03__System.Data.SqlClient_.Entities;
using SimpleApp03__System.Data.SqlClient_.Models.DTOs;

namespace SimpleApp03__System.Data.SqlClient_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private IPrescriptionsRepository _rescriptionsRepository;

        public PrescriptionsController(IPrescriptionsRepository rescriptionsRepository)
        {
            _rescriptionsRepository = rescriptionsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrescriptionsAsync(string? PatientName)
        {
            var list = await _rescriptionsRepository.GetPrescriptionsAsync(PatientName);
            return Ok(list);
        }

        [HttpPost("/{IdPrescription:int}")]
        public async Task<IActionResult> AddMedicineToPrescriptionAsync (int IdPrescription, List<PostMedicinePrescription> mp) 
        { 
            var request = await _rescriptionsRepository.AddMedicineToPrescriptionTransactionAsync(IdPrescription, mp);
            return StatusCode(request.Code, (request.ReturnInformation ? request.Information : "") );
        }
    }
}
