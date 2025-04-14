using GoF.Structural.AdapterFamily.Proxy.AccessOption1.Entities.Visitors;

namespace GoF.Structural.AdapterFamily.Proxy.AccessOption1.Interfaces
{
    public interface IRestaurant
    {
        public void ComeIn(RestaurantVisitor visitor);
        public void ComeOut(RestaurantVisitor visitor);
        public void MakeOrder(RestaurantVisitor visitor, float order);
        public void Pay(RestaurantVisitor visitor);
    }
}
