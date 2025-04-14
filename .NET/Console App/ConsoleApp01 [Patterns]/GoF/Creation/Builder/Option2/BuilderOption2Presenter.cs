namespace GoF.Creation.Builder.Option2
{
    public static class BuilderOption2Presenter
    {
        public static void Present()
        {
            var car = Director.BuildSClassCar();

            Console.WriteLine($"SClass");
            Console.WriteLine(car);
            Console.WriteLine();


            car = Director.BuildSportCar();

            Console.WriteLine($"Sport");
            Console.WriteLine(car);
        }
    }
}
