using GoF.Structural.Bridge.Interfaces;

namespace GoF.Structural.Bridge.Entities.Agents.Matrix1
{
    public class AgentBrown : IMatrixAgent
    {
        public void TellName()
        {
            Console.WriteLine("I`m Agent Brown");
        }
    }
}
