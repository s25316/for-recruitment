using GoF.Creation.AbstractFactory.Entities.FoodIngredients;
using GoF.Creation.AbstractFactory.Entities.Plates;
using GoF.Creation.AbstractFactory.Entities.Sauces;
using GoF.Creation.AbstractFactory.Interfaces.Entities;
using GoF.Creation.AbstractFactory.Interfaces.Factories;

namespace GoF.Creation.AbstractFactory.Factories
{
    public class KebabFactory : IFoodFactory
    {
        public IEnumerable<IFoodIngredient> CreateFoodIngredients()
        {
            return [
                new GrillMeat(),
                new KoreanCarrot(),
                new Salad(),
            ];
        }

        public IPlate CreatePlate()
        {
            return new FlatPlate();
        }

        public ISauce CreateSauce()
        {
            return new GarlicSauce();
        }
    }
}
