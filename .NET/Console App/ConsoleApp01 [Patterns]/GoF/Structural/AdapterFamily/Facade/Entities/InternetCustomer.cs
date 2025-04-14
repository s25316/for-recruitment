using GoF.Structural.AdapterFamily.Facade.Interfaces;

namespace GoF.Structural.AdapterFamily.Facade.Entities
{
    public class InternetCustomer : IInternetCustomer
    {
        // Properties
        private readonly List<(string Product, float Price)> _basket = new List<(string Product, float Price)>();

        public void LoginIn()
        {
            Console.WriteLine($"Customer Log In");
        }

        public void LogOut()
        {
            Console.WriteLine($"Customer Log Out");
        }

        public void Pay(float money)
        {
            var basketSum = _basket.Sum(pair => pair.Price);
            if (money >= basketSum)
            {
                Console.WriteLine($"Customer Buy, change: {money - basketSum}");
            }
            else
            {
                Console.WriteLine($"Customer can not buy, add: {basketSum - money}");
            }
        }

        public void SetAddress(string address)
        {
            Console.WriteLine($"Customer Set delivering-address: {address}");
        }

        public void SetProduct(string productName, float price)
        {
            _basket.Add((productName, price));
            Console.WriteLine($"Customer add to Basket: {productName} {price}");
        }
    }
}
