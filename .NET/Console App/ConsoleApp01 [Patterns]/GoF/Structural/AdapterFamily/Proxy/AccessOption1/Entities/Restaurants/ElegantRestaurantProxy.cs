using GoF.Structural.AdapterFamily.Proxy.AccessOption1.Entities.Visitors;
using GoF.Structural.AdapterFamily.Proxy.AccessOption1.Enums;
using GoF.Structural.AdapterFamily.Proxy.AccessOption1.Interfaces;

namespace GoF.Structural.AdapterFamily.Proxy.AccessOption1.Entities.Restaurants
{
    public class ElegantRestaurantProxy : IRestaurant
    {
        // Properties
        private readonly IRestaurant _restorunt;


        // Constructor
        public ElegantRestaurantProxy(ElegantRestaurant restorunt)
        {
            _restorunt = restorunt;
        }


        public void ComeIn(RestaurantVisitor visitor)
        {
            if (visitor.Wear != RestaurantVisitorWear.Suit)
            {
                Console.WriteLine("Cannot be enter, wear a suit");
            }

            _restorunt.ComeIn(visitor);
            if (visitor.Money == 0)
            {
                visitor.Status = RestaurantVisitorStatus.HaveNoMoney;
            }
        }

        public void ComeOut(RestaurantVisitor visitor)
        {
            if (visitor.Status == RestaurantVisitorStatus.HaveNoMoney ||
                visitor.Status == RestaurantVisitorStatus.NotPayed)
            {
                Console.WriteLine("Need to Pay, or we call Police");
            }
            else
            {
                _restorunt.ComeOut(visitor);
            }
        }

        public void MakeOrder(RestaurantVisitor visitor, float order)
        {
            _restorunt.MakeOrder(visitor, order);
            Console.WriteLine($"Make order: {order} \tMoney: {visitor.Money} \tDebt: -{visitor.Debt} = {visitor.Money - visitor.Debt}");
        }

        public void Pay(RestaurantVisitor visitor)
        {
            _restorunt.Pay(visitor);
            if (visitor.Status == RestaurantVisitorStatus.Payed)
            {
                Console.WriteLine($"Visitor Payed, Money: {visitor.Money}");

            }
        }
    }
}
