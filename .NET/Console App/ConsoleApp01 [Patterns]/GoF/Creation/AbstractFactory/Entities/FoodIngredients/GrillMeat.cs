using GoF.Creation.AbstractFactory.Interfaces.Entities;

namespace GoF.Creation.AbstractFactory.Entities.FoodIngredients
{
    public class GrillMeat : IFoodIngredient
    {
        public void WhichIngredient()
        {
            Console.Write("Meat on Grill");
        }
    }
}
