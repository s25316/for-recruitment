using GoF.Structural.AdapterFamily.Facade.Entities;

namespace GoF.Structural.AdapterFamily.Facade
{
    public static class FacadePresenter
    {
        public static void Present()
        {
            var facade = new InternetCustomerFacade(new InternetCustomer());
            facade.Buy(
                100,
                "Jana Pawla II 10, 00-001 Warsaw",
                [
                    ("Meat", 10),
                    ("Fish", 10),
                    ("Pizza", 30),
                    ("Sushi", 50),
                    ("Potato", 5),
                ]);
        }
    }
}
