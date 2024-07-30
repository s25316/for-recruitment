using MAS03.Models;

namespace MAS03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //• Klasa abstrakcyjna i polimorficzne wołanie metod
            var listOfAnimal = new List<Animal>();
            listOfAnimal.Add(new Bird("Kuracak", true, false, 2, 2));
            listOfAnimal.Add(new Bird("Kaczka", true, true, 2, 2));
            listOfAnimal.Add(new Mammal("Człowiek", false, true, 0, 0, 0, 4));
            listOfAnimal.Add(new Mammal("Kaczodziob", false, true, 0, 4, 0, 1));

            foreach (var animal in listOfAnimal) { Console.WriteLine(animal.Description()); }
            //======================================================================================================
            //• Overlapping
            var p1 = new CouncilPerson { FirstName = "John", LastName = "Reeese" };

            try { p1.MoneySkillLevel = 1; } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { p1.DiplomacySkillLevel = 1; } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { p1.FightSkillLevel = 1; } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { p1.IntrigueSkillLevel = 1; } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { p1.SanctitySkillLevel = 1; } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            Console.WriteLine("============================");
            try { Console.WriteLine(p1.MoneySkillLevel); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { Console.WriteLine(p1.DiplomacySkillLevel); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { Console.WriteLine(p1.FightSkillLevel); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { Console.WriteLine(p1.IntrigueSkillLevel); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { Console.WriteLine(p1.SanctitySkillLevel); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            Console.WriteLine("============================");
            Console.WriteLine(p1);
            Console.WriteLine("============================");
            p1.CouncilKindList.Add(CouncilKind.Stewart);
            try { p1.MoneySkillLevel = 1; } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { Console.WriteLine($"Money Skill Level - {p1.MoneySkillLevel}"); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            Console.WriteLine("============================");
            Console.WriteLine(p1);
            Console.WriteLine("============================");
            //======================================================================================================
            //• Wielodziedziczenie
            var ccSelller1 = new CallCenterSellerEmployee("Tomas", "Crown", 80, (float)(10.5), 15000, 80, (float)(24.45));
            Console.WriteLine($"Salary {ccSelller1.GetSalary()} = CC {ccSelller1.GetSalaryAsCC()} + Seller {ccSelller1.GetSalaryAsSeller()}");
            Console.WriteLine("============================");
            //======================================================================================================
            //• Wieloaspektowe
            Cream c1 = new MedicalCream("Zaza", new Head("Oczy", "Leczenie zapalenia spojówek"), new List<string>() { "sas", "ddd" }, (float)(1.29));
            Cream c2 = new TonalCream("Dada", new Body("Dla aktorów"), (float)(0.5), 5);
            Console.WriteLine(c1.GetProportion(80));
            Console.WriteLine(c2.GetProportion(80));
            //======================================================================================================
            //• Dynamiczne
            Console.WriteLine("============================");
            var ruler1 = new RulerPerson
            {
                TerritorialUnitsNumber = 10,
                FirstName = "Mark",
                LastName = "Snow"
            };

            try { Console.WriteLine(ruler1.KingdomsNumber); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { Console.WriteLine(ruler1.Crown); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { Console.WriteLine(ruler1.EmpiresNumber); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { Console.WriteLine(ruler1.CoinsNumberWithEmperor); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            Console.WriteLine(ruler1);
            Console.WriteLine("============================");
            ruler1.TerritorialUnitsNumber = 16;

            try { Console.WriteLine(ruler1.KingdomsNumber); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { Console.WriteLine(ruler1.Crown); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { Console.WriteLine(ruler1.EmpiresNumber); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { Console.WriteLine(ruler1.CoinsNumberWithEmperor); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            Console.WriteLine(ruler1);
            Console.WriteLine("============================");
            ruler1.TerritorialUnitsNumber = 56;

            try { Console.WriteLine(ruler1.KingdomsNumber); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { Console.WriteLine(ruler1.Crown); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { Console.WriteLine(ruler1.EmpiresNumber); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try { Console.WriteLine(ruler1.CoinsNumberWithEmperor); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            Console.WriteLine(ruler1);

            Console.WriteLine("END :)");
        }
    }
}
