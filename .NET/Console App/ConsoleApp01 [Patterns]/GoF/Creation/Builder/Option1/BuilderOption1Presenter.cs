using GoF.Creation.Builder.Option1.Builders;

namespace GoF.Creation.Builder.Option1
{
    public static class BuilderOption1Presenter
    {
        public static void Present()
        {
            CarBuilder builder = new SClassCarBuilder();
            var director = new Director(builder);
            var car = director.Build();

            Console.WriteLine($"{nameof(SClassCarBuilder)}");
            Console.WriteLine(car);
            Console.WriteLine();


            builder = new SportClassCarBuilder();
            director.Builder = builder;
            car = director.Build();

            Console.WriteLine($"{nameof(SportClassCarBuilder)}");
            Console.WriteLine(car);
        }
    }
}
