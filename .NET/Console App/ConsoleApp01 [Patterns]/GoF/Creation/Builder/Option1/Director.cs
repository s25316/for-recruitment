using GoF.Creation.Builder.Option1.Builders;
using GoF.Creation.Builder.Option1.Entities;

namespace GoF.Creation.Builder.Option1
{
    public class Director
    {
        // Property
        public CarBuilder Builder { get; set; }


        // Constructor
        public Director(CarBuilder builder)
        {
            Builder = builder;
        }


        // Methods
        public Car Build() => Builder
            .SetDoorsCount()
            .SetWheelCount()
            .SetCylinderCount()
            .SetCorpusType()
            .SetWheelbaseType()
            .SetDescription()
            .Build();
    }
}
