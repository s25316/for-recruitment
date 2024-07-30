namespace Radon.Models.Courses.MyResponse
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
        public IEnumerable<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
        public int Count { get; set; } = 0;
    }
}
