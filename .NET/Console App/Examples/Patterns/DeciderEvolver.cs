// Ignore Spelling: Evolver
namespace Patterns
{
    /* ALWAYS:
     * 
     * State
     * Command
     * Event
     */

    public static class Evolver
    {
        public static State Evolve(this State state, Event @event)
        {
            return (state, @event) switch
            {
                (State.Active s, Event.Add c) => new State.Active(s.Points + c.Points),
                (State.Active s, Event.Remove c) => s.Points - c.Points < 0
                    ? s
                    : new State.Active(s.Points - c.Points),
                (State.Active s, Event.Block c) => new State.Blocked(s.Points),

                (State.Blocked s, Event.Add c) => s,
                (State.Blocked s, Event.Remove c) => s,
                (State.Blocked s, Event.Block c) => s,

                _ => throw new NotImplementedException(),
            };
        }
    }

    public static class Decider
    {
        //private static readonly ConcurrentQueue<string> queue = new(); // FIFO
        //private static readonly ConcurrentStack<string> topic = new(); // LIFO

        public static IEnumerable<Event> Decide(this State state, Command command)
        {
            return (state, command) switch
            {
                (State.Active s, Command.Add c) => Add(s, c),
                (State.Active s, Command.Remove c) => Remove(s, c),
                (State.Active s, Command.Block c) => [new Event.Block()],

                (State.Blocked s, Command.Add c) => [new Event.Deny("")],
                (State.Blocked s, Command.Remove c) => [new Event.Deny("")],
                (State.Blocked s, Command.Block c) => [new Event.Deny("")],

                _ => throw new NotImplementedException(),
            };
        }

        private static IEnumerable<Event> Remove(State state, Command command)
        {
            return [];
        }

        private static IEnumerable<Event> Add(State state, Command command)
        {
            return [];
        }
    }

    public abstract record State
    {
        public record Active(int Points) : State;
        public record Blocked(int Points) : State;
    }

    public abstract record Command
    {
        public record Add(int Points) : Command;
        public record Remove(int Points) : Command;
        public record Block() : Command;
    }

    public abstract record Event
    {
        public record Add(int Points) : Event;
        public record Remove(int Points) : Event;
        public record Block() : Event;
        public record Deny(string ErrorMessage) : Event;
    }
}
