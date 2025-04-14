using GoF.Creation.AbstractFactory.Interfaces.Entities;

namespace GoF.Creation.AbstractFactory.Entities.Plates
{
    public class FlatPlate : IPlate
    {
        public void WhichPlate()
        {
            Console.WriteLine($"Plate: Flat/Dinner/Serving");
        }
    }
}
