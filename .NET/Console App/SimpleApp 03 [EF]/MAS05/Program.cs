using MAS05.DatabaseLayer;
using MAS05.DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace MAS05
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            BeeDBContext context = new BeeDBContext();
            await context.SaveChangesAsync();
            /*
            • MR - klasy
            • MR – asocjacje (1:* lub *:*)
            • MR - dziedzicz.
             */
            await context.Bees.AddAsync(
                new Bee { Name = "Bz", BirthDate = DateOnly.FromDateTime(DateTime.Now) });
            await context.SaveChangesAsync();
            Console.WriteLine("===========================================================");

            var listBees = await context.Bees.ToListAsync();
            listBees.ForEach(async item =>
            {
                Console.WriteLine($"Pszczoła: Id {item.IdBee},\t\tName {item.Name}");
                await context.BeeHomeAndBee.AddAsync(new BeeHomeAndBee { IdBee = item.IdBee, IdBeeHome = 1});                
            });
            await context.SaveChangesAsync();

            Console.WriteLine("===========================================================");
            var listBeeIntelligences = await context.BeeIntelligences.Include(b => b.Bee)
                .Select(b => new {b.IdBee, b.Bee.Name, b.Bee.BirthDate, b.Distance }).ToListAsync();
            listBeeIntelligences.ForEach(item =>
            {
                Console.WriteLine(
                    $"Pszczoła Wywiadowca: Id {item.IdBee},\t\t Name {item.Name},\t Distance: {item.Distance}");
            });

            Console.WriteLine("===========================================================");
            var listBeeSecurities = await context.BeeSecurities.Include(b => b.Bee)
                .Select(b => new { b.IdBee, b.Bee.Name, b.Bee.BirthDate, b.Power }).ToListAsync();
            listBeeSecurities.ForEach(item =>
            {
                Console.WriteLine(
                    $"Pszczoła Ochroniarz: Id {item.IdBee},\t\t Name {item.Name},\t Power: {item.Power}");
            });

            Console.WriteLine("===========================================================");
            var listBeeHomes = await context.BeeHomes.Include(b => b.BeeHomeAndBees)
                .ThenInclude(b => b.Bee).Select(h => new 
                { 
                    h.IdBeeHome, 
                    h.Name, 
                    Bees = h.BeeHomeAndBees.Select(b => new { b.IdBee, b.Bee.Name }).ToList(),
                })
                .ToListAsync();

            listBeeHomes.ForEach(item => { 
                Console.WriteLine($"Ul: ID {item.IdBeeHome}, Name {item.Name}\nPsczoły należące do danego ulu:");
                item.Bees.ForEach(b => 
                { 
                    Console.WriteLine($"Pszczoła z ulu {item.IdBeeHome}: Id {b.IdBee}, Name {b.Name}"); 
                });
            });
        } 
    }
}
