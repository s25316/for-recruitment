namespace GangOfFour.Behavioral
{
    public record Memento<T>
    {
        public DateTimeOffset TimeStamp { get; init; } = DateTimeOffset.Now;
        public required T Snapshot { get; init; }
    };

    // Prototype used for simplify code 
    public interface IPrototype<out T>
    {
        T Copy();
    }

    public interface IMemento<T>
    {
        Memento<T> Save();
        void Restore(Memento<T> memento);
    }

    public abstract class Storage<T> // Caretaker
    {
        private readonly Stack<Memento<T>> stack = new();

        public void SetMemento(Memento<T> memento) => stack.Push(memento);
        public Memento<T>? GetMemento()
        {
            return stack.TryPop(out var lastItem) ? lastItem : null;
        }
    }

    public class PersonProfile : IMemento<PersonProfile>, IPrototype<PersonProfile>
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Document { get; set; } = null!;


        public PersonProfile Copy() => new PersonProfile
        {
            Name = Name,
            Surname = Surname,
            Document = Document
        };

        public void Restore(Memento<PersonProfile> memento)
        {
            Name = memento.Snapshot.Name;
            Surname = memento.Snapshot.Surname;
            Document = memento.Snapshot.Document;
        }

        public Memento<PersonProfile> Save() => new Memento<PersonProfile>
        {
            Snapshot = Copy(),
        };
    }
}


