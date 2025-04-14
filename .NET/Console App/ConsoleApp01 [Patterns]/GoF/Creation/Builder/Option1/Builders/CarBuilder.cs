using GoF.Creation.Builder.Option1.Entities;

namespace GoF.Creation.Builder.Option1.Builders
{
    public abstract class CarBuilder
    {
        // Properties
        protected readonly Car _car = new Car();


        // Methods 
        public abstract CarBuilder SetDoorsCount();

        public abstract CarBuilder SetWheelCount();
        public abstract CarBuilder SetCylinderCount();

        public abstract CarBuilder SetCorpusType();

        public abstract CarBuilder SetWheelbaseType();

        public abstract CarBuilder SetDescription();

        public Car Build() => _car;
    }
}
