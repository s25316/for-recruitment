using Radon.Models.Institutions.ApiResponse;

namespace Radon.Models.Institutions.MyResponse
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
        public EntityResponse? Response { get; set; } = null;    
    }
}
