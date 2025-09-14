namespace UnifiedModelingLanguage
{
    public record BagObject1
    {
        private readonly List<Bag> bags = [];
        private readonly List<History> histories = [];


        public void AddBag(Bag bag) => bags.Add(bag);
        public void AddHistory(History history) => histories.Add(history);
    }

    public record BagObject2
    {
        private readonly List<Bag> bags = [];
        private readonly List<History> histories = [];


        public void AddBag(Bag bag) => bags.Add(bag);
        public void AddHistory(History history) => histories.Add(history);
    }

    /// <summary>
    /// {Bag} - if we can be added the same objects many times
    /// </summary>
    public class Bag
    {
        public BagObject1 Object1 { get; }
        public BagObject2 Object2 { get; }

        public Bag(BagObject1 object1, BagObject2 object2)
        {
            Object1 = object1;
            Object2 = object2;

            Object1.AddBag(this);
            Object2.AddBag(this);
        }
    };

    /// <summary>
    /// {History} - {Bag} with date/dates
    /// </summary>
    public class History
    {
        public BagObject1 Object1 { get; }
        public BagObject2 Object2 { get; }
        public DateTimeOffset From { get; }
        public DateTimeOffset To { get; }

        public History(BagObject1 object1, BagObject2 object2, DateTimeOffset from, DateTimeOffset to)
        {
            Object1 = object1;
            Object2 = object2;
            From = from;
            To = to;

            Object1.AddHistory(this);
            Object2.AddHistory(this);
        }
    };
}
