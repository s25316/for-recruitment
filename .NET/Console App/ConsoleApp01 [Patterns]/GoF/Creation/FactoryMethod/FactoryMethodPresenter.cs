using GoF.Creation.FactoryMethod.Factories;
using GoF.Creation.FactoryMethod.Interfaces;

namespace GoF.Creation.FactoryMethod
{
    public static class FactoryMethodPresenter
    {
        public static void Present()
        {
            var water1 = GetFactory(20);
            water1.FactoryMethod().PrintState();

            var water2 = GetFactory(-1);
            water2.FactoryMethod().PrintState();

            var water3 = GetFactory(100);
            water3.FactoryMethod().PrintState();
        }

        public static IWaterFactory GetFactory(float temperature)
        {
            if (temperature < 0)
            {
                return new IceFactory();
            }
            else if (temperature >= 100)
            {
                return new SteamFactory();
            }
            else
            {
                return new WaterFactory();
            }
        }
    }
}
