using GoF.Structural.AdapterFamily.Proxy.AccessOption1.Entities.Visitors;
using GoF.Structural.AdapterFamily.Proxy.AccessOption1.Enums;
using GoF.Structural.AdapterFamily.Proxy.AccessOption1.Interfaces;

namespace GoF.Structural.AdapterFamily.Proxy.AccessOption1.Entities.Restaurants
{
    public class ElegantRestaurant : IRestaurant
    {
        public void ComeIn(RestaurantVisitor visitor)
        {
            Console.WriteLine("Come In");
            visitor.Status = RestaurantVisitorStatus.Inside;
        }

        public void ComeOut(RestaurantVisitor visitor)
        {
            Console.WriteLine("Come Out");
            visitor.Status = RestaurantVisitorStatus.Outside;
        }

        public void MakeOrder(RestaurantVisitor visitor, float order)
        {
            if (order > 0)
            {
                visitor.Debt += order;
                visitor.Status = RestaurantVisitorStatus.NotPayed;
            }
        }

        public void Pay(RestaurantVisitor visitor)
        {
            if (visitor.Money >= visitor.Debt)
            {
                visitor.Money -= visitor.Debt;
                visitor.Debt = 0;
                visitor.Status = RestaurantVisitorStatus.Payed;
            }
        }
    }
}
