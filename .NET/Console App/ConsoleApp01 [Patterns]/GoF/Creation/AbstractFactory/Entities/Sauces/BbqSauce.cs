using GoF.Creation.AbstractFactory.Interfaces.Entities;

namespace GoF.Creation.AbstractFactory.Entities.Sauces
{
    public class BbqSauce : ISauce
    {
        public void WhichSauce()
        {
            Console.WriteLine("Sauce: BBQ");
        }
    }
}
