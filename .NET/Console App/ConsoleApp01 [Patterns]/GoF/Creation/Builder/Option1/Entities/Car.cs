namespace GoF.Creation.Builder.Option1.Entities
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
    }
}
