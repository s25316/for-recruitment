using GoF.Creation.AbstractFactory.Interfaces.Entities;

namespace GoF.Creation.AbstractFactory.Entities.FoodIngredients
{
    public class Salad : IFoodIngredient
    {
        public void WhichIngredient()
        {
            Console.Write("Salad");
        }
    }
}
