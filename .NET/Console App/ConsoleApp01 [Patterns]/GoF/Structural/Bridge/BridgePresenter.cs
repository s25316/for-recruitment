using GoF.Structural.Bridge.Entities.Agents.Matrix1;
using GoF.Structural.Bridge.Entities.Agents.Matrix2;
using GoF.Structural.Bridge.Entities.Bridges;
using GoF.Structural.Bridge.Interfaces;

namespace GoF.Structural.Bridge
{
    public static class BridgePresenter
    {
        public static void Present()
        {
            IMatrixAgentBridge bridge;

            bridge = new AgentBridge1(new AgentSmith());
            bridge.TellNames();

            Console.WriteLine();
            Console.WriteLine("Matrix 1");
            bridge = new AgentBridge2([
                new AgentSmith(),
                new AgentBrown(),
                new AgentJones(),
                ]);
            bridge.TellNames();

            Console.WriteLine();
            Console.WriteLine("Matrix 2");
            bridge = new AgentBridge2([
                new AgentJohnson(),
                new AgentJackson(),
                new AgentThompson(),
                ]);
            bridge.TellNames();

            /*bridge = new AgentBridge2( HERE IS BRIDGE );*/
        }
    }
}
