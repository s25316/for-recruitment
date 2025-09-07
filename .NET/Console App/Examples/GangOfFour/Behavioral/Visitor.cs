namespace GangOfFour.Behavioral
{
    /// ... for each item, class, abstraction individual method => void Visit(T item);
    public interface IVisitor
    {
        void Visit(VisitorItem1 item);
        void Visit(VisitorItem2 item);
    }

    public interface IVisitorItem
    {
        void Invoke(IVisitor visitor);
    }

    public class VisitorItem1(string Name) : IVisitorItem
    {
        public void Fly() => Console.WriteLine($"{nameof(VisitorItem1)} : {Name} flying!!!");
        public void Invoke(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class VisitorItem2(string Name, string Surname) : IVisitorItem
    {
        public void Ride() => Console.WriteLine($"{nameof(VisitorItem2)} : {Name} {Surname} riding!!!");
        public void Invoke(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Visitor : IVisitor
    {
        public void Visit(VisitorItem1 item)
        {
            item.Fly();
        }

        public void Visit(VisitorItem2 item)
        {
            item.Ride();
        }
    }

    public static class VisitorHandler
    {
        public static void VisitAll(IEnumerable<IVisitorItem> items, IVisitor visitor)
        {
            foreach (var item in items)
            {
                item.Invoke(visitor);
            }
        }
    }
}
