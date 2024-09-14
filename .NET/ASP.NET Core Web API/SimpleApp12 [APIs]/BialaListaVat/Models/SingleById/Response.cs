using BialaListaVat.Models.SingleById.CorrectResponse;

namespace BialaListaVat.Models.SingleById
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public bool IsServerProblem { get; set; }
        public string Message { get; set; } = null!;
        public SingleCompany? Company { get; set; } = null;
    }
}
