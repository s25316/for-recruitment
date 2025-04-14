using GoF.Structural.Bridge.Interfaces;

namespace GoF.Structural.Bridge.Entities.Bridges
{
    class AgentBridge2 : IMatrixAgentBridge
    {
        // Property
        public IEnumerable<IMatrixAgent> Agents { get; set; }


        // Constructor
        public AgentBridge2(IEnumerable<IMatrixAgent> agents)
        {
            Agents = agents;
        }


        // Methods
        public void TellNames()
        {
            foreach (var agent in Agents)
            {
                agent.TellName();
            }
        }
    }
}
