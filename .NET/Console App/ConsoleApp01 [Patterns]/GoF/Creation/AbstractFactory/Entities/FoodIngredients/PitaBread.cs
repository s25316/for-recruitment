using GoF.Creation.AbstractFactory.Interfaces.Entities;

namespace GoF.Creation.AbstractFactory.Entities.FoodIngredients
{
    public class PitaBread : IFoodIngredient
    {
        public void WhichIngredient()
        {
            Console.Write("Pita [Bread]");
        }
    }
}
