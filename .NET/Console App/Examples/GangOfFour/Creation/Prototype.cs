namespace GangOfFour.Creation
{
    public interface ICopyable<out T>
    {
        T Copy(); // Clone
    }

    public class AgentSmith : ICopyable<AgentSmith>
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Text { get; set; } = null!;


        public AgentSmith Copy() => new AgentSmith
        {
            Name = Name,
            Surname = Surname,
            Text = Text
        };
    }
}
