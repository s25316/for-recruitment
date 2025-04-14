using GoF.Creation.AbstractFactory.Interfaces.Entities;

namespace GoF.Creation.AbstractFactory.Entities.Plates
{
    public class DeepPlate : IPlate
    {
        public void WhichPlate()
        {
            Console.WriteLine($"Plate: Deep/Soup/Bowl");
        }
    }
}
