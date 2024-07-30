using BialaListaVat.Models.SingleById.CorrectResponse;

namespace BialaListaVat.Models.SingleById
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
        public Subject? Company { get; set; } = null;
    }
}
