using GoF.Creation.AbstractFactory.Interfaces.Entities;

namespace GoF.Creation.AbstractFactory.Interfaces.Factories
{
    public interface IFoodFactory
    {
        ISauce CreateSauce();
        IPlate CreatePlate();
        IEnumerable<IFoodIngredient> CreateFoodIngredients();
    }
}
