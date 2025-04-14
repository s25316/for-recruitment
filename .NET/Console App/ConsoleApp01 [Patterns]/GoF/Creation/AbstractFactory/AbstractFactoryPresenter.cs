using GoF.Creation.AbstractFactory.Factories;
using GoF.Creation.AbstractFactory.Interfaces.Factories;

namespace GoF.Creation.AbstractFactory
{
    public static class AbstractFactoryPresenter
    {
        public static void Present()
        {
            IFoodFactory factory;


            factory = new KebabFactory();
            PrintFactory(factory);


            factory = new SteakFactory();
            PrintFactory(factory);
        }

        private static void PrintFactory(IFoodFactory factory)
        {
            Console.WriteLine(factory.GetType().Name);
            factory.CreatePlate().WhichPlate();

            Console.Write("Ingredients: ");
            foreach (var ingredient in factory.CreateFoodIngredients())
            {
                ingredient.WhichIngredient();
            }
            Console.WriteLine();
            factory.CreateSauce().WhichSauce();
            Console.WriteLine();
        }
    }
}
