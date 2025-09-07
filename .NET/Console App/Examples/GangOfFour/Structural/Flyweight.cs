namespace GangOfFour.Structural
{
    public interface IFlyweightOperation
    {
        string Concatenate(string value);
    }

    public sealed record FlyweightItem(string Start, string End) : IFlyweightOperation
    {
        public string Concatenate(string value) => $"{Start} {value} {End}";
    }

    public sealed class FlyweightFactory
    {
        private readonly Dictionary<string, IFlyweightOperation> dictionary = [];


        public IFlyweightOperation Get(string key)
        {
            if (dictionary.Count == 0)
            {
                // All implementation HERE, ADD no exist
                dictionary["basic"] = new FlyweightItem("Hi ", "we want to invite... Have a nice day... ");
                dictionary["classic"] = new FlyweightItem("Dear", "we kindly please You to join ... Kind regards...");
            }

            return dictionary.TryGetValue(key, out var operation)
                ? operation
                : throw new NotImplementedException();
        }
    }
}
