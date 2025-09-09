namespace Patterns
{
    public sealed record Result
    {
        public bool IsSuccess { get; private set; } = true;
        public Error Error { get; private set; } = Error.None;


        public static Result Success => new();
        public static Result Failure(string errorMessage) => new()
        {
            IsSuccess = false,
            Error = new Error(errorMessage),
        };
    }

    public sealed record Error(string? Descritpion = null)
    {
        public static Error None => new();
    }
}
