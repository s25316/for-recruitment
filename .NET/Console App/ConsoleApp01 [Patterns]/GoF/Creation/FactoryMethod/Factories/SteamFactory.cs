using GoF.Creation.FactoryMethod.Entities;
using GoF.Creation.FactoryMethod.Interfaces;

namespace GoF.Creation.FactoryMethod.Factories
{
    public class SteamFactory : IWaterFactory
    {
        public IWater FactoryMethod()
        {
            return new Steam();
        }
    }
}
