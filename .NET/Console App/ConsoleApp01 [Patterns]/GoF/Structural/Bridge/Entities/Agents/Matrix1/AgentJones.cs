using GoF.Structural.Bridge.Interfaces;

namespace GoF.Structural.Bridge.Entities.Agents.Matrix1
{
    public class AgentJones : IMatrixAgent
    {
        public void TellName()
        {
            Console.WriteLine("I`m Agent Jones");
        }
    }
}
