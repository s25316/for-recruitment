namespace SimpleApp10__EF__CdF_JWT_.BusinessLogicLayer.Authentication.DTOs
{
    public class ResponseDTO<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
        public T? Value { get; set; }
    }
}
