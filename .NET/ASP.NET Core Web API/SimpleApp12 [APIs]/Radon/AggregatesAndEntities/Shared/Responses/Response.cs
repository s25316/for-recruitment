namespace Radon.AggregatesAndEntities.Shared.Responses
{
    public class Response<T> : ResponseTemplate where T : class
    {
        public T? Item { get; set; } = null;


        public static Response<T> FromTemplate(ResponseTemplate template)
        {
            return new Response<T>
            {
                IsSuccess = template.IsSuccess,
                Problem = template.Problem,
                MessageForUser = template.MessageForUser,
                MessageForAdmin = template.MessageForAdmin,
                Item = null,
            };
        }
    }
}
