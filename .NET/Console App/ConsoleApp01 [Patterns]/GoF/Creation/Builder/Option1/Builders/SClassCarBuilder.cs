namespace GoF.Creation.Builder.Option1.Builders
{
    public class SClassCarBuilder : CarBuilder
    {
        public override CarBuilder SetDoorsCount()
        {
            _car.DoorsCount = 4;
            return this;
        }

        public override CarBuilder SetWheelCount()
        {
            _car.WheelCount = 4;
            return this;
        }

        public override CarBuilder SetCylinderCount()
        {
            _car.CylinderCount = 16;
            return this;
        }

        public override CarBuilder SetCorpusType()
        {
            _car.CorpusType = "Sedan";
            return this;
        }

        public override CarBuilder SetWheelbaseType()
        {
            _car.WheelbaseType = "4x4";
            return this;
        }

        public override CarBuilder SetDescription()
        {
            _car.Description = "Bulletproof glass";
            return this;
        }
    }
}
