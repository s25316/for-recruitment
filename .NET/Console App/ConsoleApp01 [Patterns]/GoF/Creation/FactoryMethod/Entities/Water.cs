using GoF.Creation.FactoryMethod.Interfaces;

namespace GoF.Creation.FactoryMethod.Entities
{
    public class Water : IWater
    {
        public void PrintState()
        {
            Console.WriteLine($"Status: {nameof(Water)}");
        }
    }
}
