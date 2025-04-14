using GoF.Structural.Bridge.Interfaces;

namespace GoF.Structural.Bridge.Entities.Agents.Matrix2
{
    public class AgentJohnson : IMatrixAgent
    {
        public void TellName()
        {
            Console.WriteLine("I`m Agent Johnson");
        }
    }
}
