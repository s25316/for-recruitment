using GoF.Creation.FactoryMethod.Interfaces;

namespace GoF.Creation.FactoryMethod.Entities
{
    class Steam : IWater
    {
        public void PrintState()
        {
            Console.WriteLine($"Status: {nameof(Steam)}");
        }
    }
}
