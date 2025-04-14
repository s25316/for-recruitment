namespace GoF.Creation.Builder.Option1.Builders
{
    public class SportClassCarBuilder : CarBuilder
    {
        public override CarBuilder SetDoorsCount()
        {
            _car.DoorsCount = 2;
            return this;
        }

        public override CarBuilder SetWheelCount()
        {
            _car.WheelCount = 4;
            return this;
        }

        public override CarBuilder SetCylinderCount()
        {
            _car.CylinderCount = 24;
            return this;
        }

        public override CarBuilder SetCorpusType()
        {
            _car.CorpusType = "Sport";
            return this;
        }

        public override CarBuilder SetWheelbaseType()
        {
            _car.WheelbaseType = "Back";
            return this;
        }

        public override CarBuilder SetDescription()
        {
            _car.Description = "Carbon corpus";
            return this;
        }
    }
}
