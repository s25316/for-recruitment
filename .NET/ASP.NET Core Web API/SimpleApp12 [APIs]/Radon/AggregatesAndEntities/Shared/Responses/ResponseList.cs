namespace Radon.AggregatesAndEntities.Shared.Responses
{
    public class ResponseList<T> : ResponseTemplate where T : class
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int Count { get; set; } = 0;

        public static ResponseList<T> FromTemplate(ResponseTemplate template)
        {
            return new ResponseList<T>
            {
                IsSuccess = template.IsSuccess,
                Problem = template.Problem,
                MessageForUser = template.MessageForUser,
                MessageForAdmin = template.MessageForAdmin,
                Items = new List<T>(),
            };
        }
    }
}
