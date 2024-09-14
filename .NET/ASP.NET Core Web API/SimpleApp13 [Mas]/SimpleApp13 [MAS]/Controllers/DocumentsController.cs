using Application.Repositories;
using Application.Repositories.DTOs.DocumentPart;
using Microsoft.AspNetCore.Mvc;

namespace SimpleApp13__MAS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IUseCasesRepository _repository;

        public DocumentsController(IUseCasesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetDocumentTypesAsync()
        {
            var result = await _repository.GetDocumentTypesAsync();
            return Ok(result);
        }

        [HttpPost("post")]
        public async Task<IActionResult> SetDocumentAsync(Guid personId, DocumentDtoRequest req)
        {
            var result = await _repository.SetDocumentAsync(personId, req);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateDocumentAsync(Guid documentId, DocumentDtoRequest req)
        {
            var result = await _repository.UpdateDocumentAsync(documentId, req);
            return Ok(result);
        }
    }
}
