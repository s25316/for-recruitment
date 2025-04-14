using GoF.Structural.Bridge.Interfaces;

namespace GoF.Structural.Bridge.Entities.Bridges
{
    public class AgentBridge1 : IMatrixAgentBridge
    {
        // Property
        public IMatrixAgent Agent { get; set; }


        // Constructor
        public AgentBridge1(IMatrixAgent agent)
        {
            Agent = agent;
        }


        // Methods
        public void TellNames()
        {
            Agent.TellName();
        }
    }
}
