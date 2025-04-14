namespace GoF.Structural.AdapterFamily.Facade.Interfaces
{
    public interface IInternetCustomerFacade
    {
        void Buy(
            float money,
            string address,
            List<(string ProductName, float Price)> basket);
    }
}
