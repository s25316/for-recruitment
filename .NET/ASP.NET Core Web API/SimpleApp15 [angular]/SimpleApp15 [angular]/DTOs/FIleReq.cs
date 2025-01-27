using System.ComponentModel.DataAnnotations;

namespace SimpleApp15__angular_.DTOs
{
    public class FIleReq
    {
        [Required]
        public IFormFile File { get; init; } = null!;
        //public ICollection<IFormFile> File { get; init; } = null!;
        /*
        public IFormFile File2 { get; init; } = null!;
        public string Message { get; init; } = null!;
        public string Message2 { get; init; } = null!;
        public string Message3 { get; init; } = null!;
        public string Message4 { get; init; } = null!;
        public string Message5 { get; init; } = null!;
        */
    }
}
