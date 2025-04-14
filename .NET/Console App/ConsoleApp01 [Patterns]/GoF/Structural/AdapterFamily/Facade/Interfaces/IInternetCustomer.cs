namespace GoF.Structural.AdapterFamily.Facade.Interfaces
{
    public interface IInternetCustomer
    {
        public void LoginIn();
        public void LogOut();
        public void SetProduct(string productName, float price);
        public void SetAddress(string address);
        public void Pay(float money);
    }
}
