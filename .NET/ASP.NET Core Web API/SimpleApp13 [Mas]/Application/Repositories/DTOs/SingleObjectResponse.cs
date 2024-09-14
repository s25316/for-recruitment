namespace Application.Repositories.DTOs
{
    public class SingleObjectResponse<T> : Response
    {
        public T? Value { get; set; }
    }
}
