using Application.Repositories;
using Application.Repositories.DTOs.PersonCreateProfile;
using Microsoft.AspNetCore.Mvc;

namespace SimpleApp13__MAS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IUseCasesRepository _repository;

        public PersonController(IUseCasesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetPeopleAsync()
        {
            var result = await _repository.GetSimpleDataPeopleAsync();
            return Ok(result);
        }

        [HttpGet("{pesel}")]
        public async Task<IActionResult> GetPersonByPeselAsync(string pesel)
        {
            var result = await _repository.GetPersonByPeselAsync(pesel);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> PersonCreateProfileAsync
            (PersonDtoRequest req)
        {
            var result = await _repository.PersonCreateProfileAsync(req);
            return Ok(result);
        }

        [HttpPut("{id:guid}/update")]
        public async Task<IActionResult> PersonUpdateProfileAsync
            (Guid id, PersonDtoRequest req)
        {
            var result = await _repository.PersonCreateProfileAsync(req);
            return Ok(result);
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteProfileAsync(Guid id)
        {
            var result = await _repository.DeleteProfileAsync(id);
            return Ok(result);
        }
    }
}
