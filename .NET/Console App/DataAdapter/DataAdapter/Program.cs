
using DataAdapter.Database;
using DataAdapter.FileAdministrativeDivisions.AsInFile.Models;
using DataAdapter.FileAdministrativeDivisions.AsInFile.Repositories;
using DataAdapter.FileAdministrativeDivisions.AsInFile.Types;
using DataAdapter.FileAdministrativeDivisions.MyOwn;
using DataAdapter.FileUniversities;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace DataAdapter
{
    internal class Program
    {
        private static readonly string _pathToCurrentDirectory =
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        private static readonly string _filesDirectory =
            $"{_pathToCurrentDirectory}/Files";
        public static async Task Main(string[] args)
        {
            var context = new MasContext();

            Console.WriteLine("Hello, World!");
            var universities = $"{_filesDirectory}/universities.csv";
            var terc = $"{_filesDirectory}/TERC_Adresowy_2024-06-03.csv";
            var simc = $"{_filesDirectory}/SIMC_Adresowy_2024-06-03.csv";
            var ulic = $"{_filesDirectory}/ULIC_Adresowy_2024-06-03.csv";

/*
            var universitiesDictionary = await new Universities(universities).GetDictionaryAsync();
            foreach (var item in universitiesDictionary.Values)
            {
                context.Companies.Add(new Company
                {
                    Id = item.Id,
                    Name = item.Name,
                    Regon = item.REGON,
                    Nip = item.NIP,
                    IsOurClient = false,
                    Email = item.Email,
                });
                context.Universites.Add(new Universite
                {
                    Id = item.Id,
                    CreatedDate = item.CreatedDate,
                    Type = item.Type,
                    LiquidationDate = item.LiquidationDate,
                    Www = item.WWW,
                    PhoneNumber = item.PhoneNumber,
                    Country = item.Country,
                    Wojewodstwo = item.Wojewodstwo,
                    Street = item.Street,
                    BuildingAndApartment = item.BuildingAndApartment,
                    ZipCode = item.ZipCode,
                    City = item.City,
                });
            }
            context.SaveChanges();
            Console.WriteLine("Add Universities");*/

            //Stopwatch sw = Stopwatch.StartNew();
            //sw.Stop();
            //Console.WriteLine("Time taken: {0}ms", sw.Elapsed.TotalMilliseconds);
            var div = new Divisions(terc, simc, ulic);

            var types = div.GetAdministrativeTypes();
            var streets = await div.GetDictionaryOfUlicAsync();
            var coloacations = await div.GetColocationsAsync();
            var structure = await div.GetStructureAsync();

            var isComplete = await div.IsCompleteDataAsync();
            /*foreach (var a in types)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine(isComplete);

            foreach (var x in types.Values)
            {
                context.AdministrativeTypes.Add(new Database.AdministrativeType
                {
                    Id = x.Id,
                    Name = x.Name,
                });
            }
            context.SaveChanges();
            Console.WriteLine("Types add");
            foreach (var s in streets.Values)
            {
                context.Streets.Add(new Database.Street
                {
                    Id = s.SymUl,
                    TypeId = (s.Cecha == null) ? null : (s.Cecha.Id),
                    Nazwa = s.Nazwa,
                });
            }
            context.SaveChanges();
            Console.WriteLine("Strets add");

            foreach (var s in structure.Values)
            {
                context.Divisions.Add(new Database.Division
                {
                    Id = s.Id,
                    TypeId = s.Type.Id,
                    ParentId = s.ParentId,
                    Name = s.Name,
                });
            }
            context.SaveChanges();
            Console.WriteLine("Structure add");*/

            /*foreach (var x in coloacations)
            {
                var division = context.Divisions.Find(x.SimcId);
                var ulica = context.Streets.Find(x.UlicId);
                if (ulica != null && division != null) 
                {
                    ulica.IdDivisions.Add(division);
                }
            }
            context.SaveChanges();*/
        }
    }
}
//Scaffold-DbContext "Data Source=localhost;Initial Catalog=MAS;Integrated Security=True;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -Output Database -Tables AdministrativeType, Adresses, Divisions, Streets, Companies, Universites, DivisionsStreets
