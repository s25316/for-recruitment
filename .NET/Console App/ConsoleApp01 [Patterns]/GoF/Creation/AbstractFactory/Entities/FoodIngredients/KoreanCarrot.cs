using GoF.Creation.AbstractFactory.Interfaces.Entities;

namespace GoF.Creation.AbstractFactory.Entities.FoodIngredients
{
    public class KoreanCarrot : IFoodIngredient
    {
        public void WhichIngredient()
        {
            Console.Write("Korean carrot");
        }
    }
}
