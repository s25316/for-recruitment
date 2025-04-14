using GoF.Structural.AdapterFamily.Facade.Interfaces;

namespace GoF.Structural.AdapterFamily.Facade.Entities
{
    public class InternetCustomerFacade : IInternetCustomerFacade
    {
        // Properties
        private readonly IInternetCustomer _customer;


        // Constructor
        public InternetCustomerFacade(IInternetCustomer customer)
        {
            _customer = customer;
        }


        // Methods
        public void Buy(
            float money,
            string address,
            List<(string ProductName, float Price)> basket)
        {
            _customer.LoginIn();
            _customer.SetAddress(address);
            foreach (var product in basket)
            {
                _customer.SetProduct(
                    product.ProductName,
                    product.Price);
            }
            _customer.Pay(money);
            _customer.LogOut();
        }
    }
}
