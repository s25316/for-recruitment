using GoF.Creation.AbstractFactory.Entities.FoodIngredients;
using GoF.Creation.AbstractFactory.Entities.Plates;
using GoF.Creation.AbstractFactory.Entities.Sauces;
using GoF.Creation.AbstractFactory.Interfaces.Entities;
using GoF.Creation.AbstractFactory.Interfaces.Factories;

namespace GoF.Creation.AbstractFactory.Factories
{
    public class SteakFactory : IFoodFactory
    {
        public IEnumerable<IFoodIngredient> CreateFoodIngredients()
        {
            return [
                new GrillMeat(),
            ];
        }

        public IPlate CreatePlate()
        {
            return new DeepPlate();
        }

        public ISauce CreateSauce()
        {
            return new BbqSauce();
        }
    }
}
