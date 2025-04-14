using GoF.Structural.AdapterFamily.Proxy.AccessOption1.Entities.Restaurants;
using GoF.Structural.AdapterFamily.Proxy.AccessOption1.Entities.Visitors;
using GoF.Structural.AdapterFamily.Proxy.AccessOption1.Enums;
using GoF.Structural.AdapterFamily.Proxy.AccessOption1.Interfaces;
using GoF.Structural.AdapterFamily.Proxy.InitializationOption2.Entities;
using GoF.Structural.AdapterFamily.Proxy.InitializationOption2.Interfaces;

namespace GoF.Structural.AdapterFamily.Proxy
{
    public static class ProxyPresenter
    {
        public static void Present()
        {
            // Access Proxy
            Console.WriteLine("Access Proxy\n");
            IRestaurant restorunt = new ElegantRestaurantProxy(
                new ElegantRestaurant()
                );

            var client = new RestaurantVisitor
            {
                Wear = RestaurantVisitorWear.SportCostume,
                Money = 100,
                Status = RestaurantVisitorStatus.Outside,
            };

            restorunt.ComeIn(client);

            client.Wear = RestaurantVisitorWear.Suit;
            restorunt.ComeIn(client);

            restorunt.MakeOrder(client, 50);
            restorunt.Pay(client);


            restorunt.MakeOrder(client, 60);
            restorunt.Pay(client);
            restorunt.ComeOut(client);
            Console.WriteLine();

            // Lazy Initialization
            Console.WriteLine("\"Lazy Loading\" Initialization Proxy");

            Console.WriteLine("\nWithout proxy");
            IServerFile file = new ServerFile("path");
            Console.WriteLine("Before get");
            file.GetFile();

            Console.WriteLine("\nWith proxy");
            file = new ServerFileProxy("path");
            Console.WriteLine("Before get");
            file.GetFile();
        }
    }
}
