namespace GoF.Creation.Builder.Option2
{
    public class Car
    {
        public int DoorsCount { get; set; } = 4;
        public int WheelCount { get; set; } = 4;
        public int CylinderCount { get; set; } = 8;
        public string CorpusType { get; set; } = null!;
        public string WheelbaseType { get; set; } = null!;
        public string Description { get; set; } = null!;

        public override string ToString()
        {
            return string.Format(
                "{0}\n{1}\n{2}\n{3}\n{4}\n{5}",
                $"{nameof(DoorsCount)}: {DoorsCount}",
                $"{nameof(WheelCount)}: {WheelCount}",
                $"{nameof(CylinderCount)}: {CylinderCount}",
                $"{nameof(CorpusType)}: {CorpusType}",
                $"{nameof(WheelbaseType)}: {WheelbaseType}",
                $"{nameof(Description)}: {Description}"
                );
        }

        public class Builder
        {
            // Properties
            protected readonly Car _car = new Car();


            // Methods 
            public Builder SetDoorsCount(int count)
            {
                _car.DoorsCount = count;
                return this;
            }

            public Builder SetWheelCount(int count)
            {
                _car.WheelCount = count;
                return this;
            }
            public Builder SetCylinderCount(int count)
            {
                _car.CylinderCount = count;
                return this;
            }

            public Builder SetCorpusType(string text)
            {
                _car.CorpusType = text;
                return this;
            }

            public Builder SetWheelbaseType(string text)
            {
                _car.WheelbaseType = text;
                return this;
            }

            public Builder SetDescription(string text)
            {
                _car.Description = text;
                return this;
            }

            public Car Build() => _car;
        }
    }
}
