using GoF.Structural.AdapterFamily.Proxy.AccessOption1.Enums;

namespace GoF.Structural.AdapterFamily.Proxy.AccessOption1.Entities.Visitors
{
    public class RestaurantVisitor
    {
        public float Money { get; set; }
        public float Debt { get; set; }
        public RestaurantVisitorWear Wear { get; set; }
        public RestaurantVisitorStatus Status { get; set; } = RestaurantVisitorStatus.Outside;
    }
}
