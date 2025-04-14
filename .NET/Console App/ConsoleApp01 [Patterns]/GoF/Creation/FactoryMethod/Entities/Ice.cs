using GoF.Creation.FactoryMethod.Interfaces;

namespace GoF.Creation.FactoryMethod.Entities
{
    public class Ice : IWater
    {
        public void PrintState()
        {
            Console.WriteLine($"Status: {nameof(Ice)}");
        }
    }
}
