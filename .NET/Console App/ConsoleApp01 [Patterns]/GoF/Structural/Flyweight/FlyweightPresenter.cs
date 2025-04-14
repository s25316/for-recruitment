using GoF.Structural.Flyweight.Entities;

namespace GoF.Structural.Flyweight
{
    public static class FlyweightPresenter
    {

        public static void Present()
        {
            var flyweight = new EditorsFlyweight();

            flyweight.GetEditor("Code").Edit("a == b;");
            flyweight.GetEditor("Code").Edit("a != b;");
            flyweight.GetEditor("Code").Edit("a ^ b;");
            flyweight.GetEditor("normal").Edit("\t aa \n");
            flyweight.GetEditor("normal").Edit("lorem");
        }
    }
}
