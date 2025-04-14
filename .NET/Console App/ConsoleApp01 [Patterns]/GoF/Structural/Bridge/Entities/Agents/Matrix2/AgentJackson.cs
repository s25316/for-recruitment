using GoF.Structural.Bridge.Interfaces;

namespace GoF.Structural.Bridge.Entities.Agents.Matrix2
{
    public class AgentJackson : IMatrixAgent
    {
        public void TellName()
        {
            Console.WriteLine("I`m Agent Jackson");
        }
    }
}
