using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp09__EF__CdF_.BusinessLogicLayer.Label.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Label
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelsController : ControllerBase
    {
        private readonly ILabelRepository _repository;
        public LabelsController(ILabelRepository repository) { _repository = repository; }


        [HttpGet]
        public async Task<IActionResult> GetLabelsAsync()
        {
            var result = await _repository.GetlabelsAsync();
            return StatusCode(200, result);
        }
        [HttpPost]
        public async Task<IActionResult> PostLabelAsync([StringLength(50)] string Name)
        {
            await _repository.PostLabelAsync(Name);
            return StatusCode(201);
        }

        [HttpDelete("{IdLabel:int}")]
        public async Task<IActionResult> DeleteLabelAsync(int IdLabel) 
        { 
            var result = await _repository.DeleteLabelAsync(IdLabel);
            return (result) ? StatusCode(202) : StatusCode(404); 
        }
    }
}
