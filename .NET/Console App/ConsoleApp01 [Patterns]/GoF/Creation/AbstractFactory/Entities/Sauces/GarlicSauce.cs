using GoF.Creation.AbstractFactory.Interfaces.Entities;

namespace GoF.Creation.AbstractFactory.Entities.Sauces
{
    public class GarlicSauce : ISauce
    {
        public void WhichSauce()
        {
            Console.WriteLine("Sauce: Garlic");
        }
    }
}
