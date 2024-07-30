using MAS04.Models;

namespace MAS04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //• Atrybutu
            //• Unique
            var list = new List<BankProfile>();
            try { 
                var bp1 = new BankProfile("ASD1213", new DateOnly(2006, 5, 11), "John", "Reese"); 
                list.Add(bp1);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            try
            {
                var bp1 = new BankProfile("ASD1213", new DateOnly(1998, 5, 11), "Mark", "Snow");
                list.Add(bp1);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            try
            {
                var bp1 = new BankProfile("ASD1213", new DateOnly(1998, 5, 11), "Mark", "Snow");
                list.Add(bp1);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            foreach (var bp in list) { Console.WriteLine(bp); }
            Console.WriteLine("==========================================\n");
            //• Subset
            var fryzjer1 = new HairDresser(1, "Jan");
            var fryzjer2 = new HairDresser(2, "Anna");

            var manager1 = new MaangerSalon(fryzjer1, "Lider");
            var salon = new HairSalon(1, "U BArbera");

            //1 Not Exist
            var status = salon.SetManager(manager1);
            Console.WriteLine(status);

            //2 Exist
            salon.SetHairDresser(fryzjer1);
            salon.SetHairDresser(fryzjer2);
            status = salon.SetManager(manager1);
            Console.WriteLine(status);
            Console.WriteLine("==========================================\n");
            //• Ordered
            var hamster1 = new Hamster("Bubik", DateOnly.FromDateTime(DateTime.Now));
            var hamster2 = new Hamster("Zubik", DateOnly.FromDateTime(DateTime.Now).AddDays(-1));
            var hamster3 = new Hamster("Abik", DateOnly.FromDateTime(DateTime.Now).AddDays(-2));

            var owner1 = new Owner("Harold", "Finch", new DateOnly(1995, 12, 1));
            var owner2 = new Owner("Harold", "Wren", new DateOnly(1995, 12, 1).AddDays(-1));
            var owner3 = new Owner("Lionel", "Fusco", new DateOnly(1995, 12, 1).AddDays(-2));

            owner1.SetHamster(hamster1);
            owner1.SetHamster(hamster2);
            owner1.SetHamster(hamster3);

            foreach (var hamster in owner1.Hamsters()) { Console.WriteLine(hamster); }
            Console.WriteLine("==========================================\n");
            hamster1.SetOwner(owner1);
            hamster1.SetOwner(owner2);
            hamster1.SetOwner(owner3);
            foreach (var owner in hamster1.Owners()) { Console.WriteLine(owner); }
            Console.WriteLine("==========================================\n");
            //• Bag
            var mam1 = new Mammal("Ozoz", "Słoń");
            var mam2 = new Mammal("Buha", "Małpa");
            var mam3 = new Mammal("Wuwu", "Delfin");

            var client1 = new CLient("Jan", "Browarczyk");
            var client2 = new CLient("Grzegoraz", "Nowak");
            var client3 = new CLient("Anna", "Stolarczyk");

            mam1.SetClientInteraction(client1,DateTime.Now);
            mam1.SetClientInteraction(client2,DateTime.Now);
            mam1.SetClientInteraction(client3,DateTime.Now);

            mam2.SetClientInteraction(client1, DateTime.Now);
            mam2.SetClientInteraction(client2, DateTime.Now);
            mam3.SetClientInteraction(client3, DateTime.Now);

            client1.SetMammalInteraction(mam1, DateTime.Now);
            client1.SetMammalInteraction(mam2, DateTime.Now);
            client1.SetMammalInteraction(mam3, DateTime.Now);

            client2.SetMammalInteraction(mam1, DateTime.Now);
            client2.SetMammalInteraction(mam2, DateTime.Now);
            client2.SetMammalInteraction(mam3, DateTime.Now);

            foreach (var mam in client1.GetMammalCLients()) { Console.WriteLine(mam); }
            Console.WriteLine("==========================================\n");
            foreach (var mam in client2.GetMammalCLients()) { Console.WriteLine(mam); }
            Console.WriteLine("==========================================\n");
            //• Xor
            var fbi1 = new FBI("ABD");
            var fbi2 = new FBI("MAS");

            var cia1 = new CIA("MAD"); 

            var agent1 = new ServiceAgent("James"); 
            var agent2 = new ServiceAgent("Felix");

            Console.WriteLine(agent1.SetFBIDepartament(fbi1));
            Console.WriteLine(agent1.SetFBIDepartament(fbi2));
            Console.WriteLine(agent1.SetCIADepartament(cia1));
            Console.WriteLine(agent1.SetFBIDepartament(null));
            Console.WriteLine(agent1.SetCIADepartament(cia1));


            Console.WriteLine(agent1.FBI);
            Console.WriteLine("==========================================\n");

            fbi1.ServiceAgents().ForEach(x => Console.WriteLine(x));
            Console.WriteLine("==========================================\n");
            fbi2.ServiceAgents().ForEach(x => Console.WriteLine(x));
            cia1.ServiceAgents().ForEach(x => Console.WriteLine(x));
            

            Console.WriteLine("==========================================\n");

            //• Ograniczenie Własne                    
            var zebra1 = new Zebra("Boba");
            var zebra2 = new Zebra("Zuba");
            var zebra3 = new Zebra("Nuba");

            var a1 = new Aviary("Pierwszy", 2);
            var a2 = new Aviary("Drugi", 2);
            
            
            Console.WriteLine(zebra1.SetToAviary(a1));
            Console.WriteLine(zebra1.SetToAviary(a1));// Unable the same
            
            Console.WriteLine(zebra2.SetToAviary(a1));
            Console.WriteLine(zebra3.SetToAviary(a1));// Overlimit

            a1.GetZebraList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine(zebra2.SetToAviary(a2));
            a1.GetZebraList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            a2.GetZebraList().ForEach(x => Console.WriteLine(x));
        }
    }
}
