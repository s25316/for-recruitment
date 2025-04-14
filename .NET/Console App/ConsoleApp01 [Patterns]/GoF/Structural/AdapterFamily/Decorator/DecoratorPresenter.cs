using GoF.Structural.AdapterFamily.Decorator.Entities;
using GoF.Structural.AdapterFamily.Decorator.Interfaces;

namespace GoF.Structural.AdapterFamily.Decorator
{
    public static class DecoratorPresenter
    {
        public static void Present()
        {
            IAccountant accountant =
                new MiddleAccountantDecorator(
                new AccountantDecorator(
                    new JuniorAccountant()));

            var competences = accountant.GetCompetences().ToList();
            Console.WriteLine(string.Join(", ", competences));
        }
    }
}
