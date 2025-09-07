using System.Text;

namespace GangOfFour.Behavioral
{
    public abstract record State(DateTimeOffset Start)
    {
        public record Sleep(DateTimeOffset From, DateTimeOffset? To) : State(From);
        public record Work(DateTimeOffset Start, float? Duration) : State(Start);
        public record Other(string Description, DateTimeOffset Start, DateTimeOffset? To) : State(Start);
    }

    public static class StateExtensionMethods
    {
        public static string Write(this State.Sleep state)
        {
            return $"I`m sleeping from {state.From} to {state.To}";
        }

        public static string Write(this State.Work state)
        {
            return $"I`m working {state.Duration} hours, from {state.Start}";
        }

        public static string Write(this State.Other state)
        {
            return $"I`m {state.Description} from {state.Start} to {state.To}";
        }
    }

    public class StateExtensionEmployee
    {
        private readonly StringBuilder diary = new StringBuilder();
        public State State { get; private set; } = new State.Sleep(DateTimeOffset.Now, null);


        public void SetState(State state)
        {
            switch (state)
            {
                case State.Sleep sleep:
                    sleep = sleep with { To = DateTimeOffset.Now };
                    diary.AppendLine(sleep.Write());
                    break;

                case State.Work work:
                    var duration = (DateTimeOffset.Now - work.Start).Minutes / 60;
                    work = work with { Duration = duration };
                    diary.AppendLine(work.Write());
                    break;

                case State.Other other:
                    other = other with { To = DateTimeOffset.Now };
                    diary.AppendLine(other.Write());
                    break;
            }

            this.State = state;
        }

        public string GetDiary() => diary.ToString();
    }
}
