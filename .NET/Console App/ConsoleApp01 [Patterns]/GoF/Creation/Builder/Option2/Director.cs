namespace GoF.Creation.Builder.Option2
{
    public static class Director
    {

        // Methods
        public static Car BuildSClassCar() => new Car.Builder()
            .SetDoorsCount(4)
            .SetWheelCount(4)
            .SetCylinderCount(16)
            .SetCorpusType("Sedan")
            .SetWheelbaseType("4x4")
            .SetDescription("Bulletproof glass")
            .Build();

        public static Car BuildSportCar() => new Car.Builder()
            .SetDoorsCount(2)
            .SetWheelCount(4)
            .SetCylinderCount(24)
            .SetCorpusType("Sport")
            .SetWheelbaseType("Back")
            .SetDescription("Carbon corpus")
            .Build();
    }
}
