using DataAdapter.FileAdministrativeDivisions.AsInFile.Models;
using DataAdapter.FileAdministrativeDivisions.AsInFile.Repositories;
using DataAdapter.FileAdministrativeDivisions.AsInFile.Types;
using DataAdapter.FileAdministrativeDivisions.MyOwn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAdapter.FileAdministrativeDivisions.MyOwn
{
    internal class Divisions
    {
        private readonly SimcReader _simcReader;
        private readonly TercReader _tercReader;
        private readonly UlicReader _ulicReader;

        private readonly Dictionary<int, Division> _dictionary = new Dictionary<int, Division>();

        public Divisions(string terc, string simc, string ulic) 
        { 
            _simcReader = new SimcReader(simc);
            _tercReader = new TercReader(terc);
            _ulicReader = new UlicReader(ulic); 
        }

        public Dictionary<int, AdministrativeType> GetAdministrativeTypes() 
        {
            return new AdministrativeType().GetDictionary();
        }
        public async Task<Dictionary<int, Ulic>> GetDictionaryOfUlicAsync() 
        {             
            return await _ulicReader.GetDictionaryAsync();
        }
        public async Task<List<SimcAndUlicColocation>> GetColocationsAsync() 
        {
            await GetDictionaryOfUlicAsync();
            return SimcAndUlicColocation.Colocations;
        }
        public async Task<bool> IsCompleteDataAsync() 
        {
            var colocations = await GetColocationsAsync();
            var colocationStructureIds = colocations.Select(x => x.SimcId).ToHashSet();

            await GetStructureAsync();

            foreach (var id in colocationStructureIds) 
            {
                if (!_dictionary.ContainsKey(id)) 
                {
                    return false;
                }
            }
            return true;
        }
        public async Task<Dictionary<int, Division>> GetStructureAsync() 
        {
            if (_dictionary.Count != 0) { return _dictionary; }
            var structure = await _tercReader.GetListAsync();
            var cities = await _simcReader.GetDictionaryAsync();

            CreateDivisionsForCities(cities);
            var removed =  RemoveDuplicatesAndMakeTheSameValues(structure, cities);

            int counter = cities.Keys.Max() + 1;
            CreateDivisionsForStructure(structure,counter);
            InsertRemovedStructureIntoStructure(structure, removed);
            CreateConnectionsBetweenDivisionsInStructure(structure);
            CreateConnectionsBetweenDivisionsInStructureAndCities(structure, cities);
            SetFullStructureIntoDictionary(structure, cities, _dictionary);
            return _dictionary;
        }

        //===================================================================================
        private static List<Terc> RemoveDuplicatesAndMakeTheSameValues
            (
            List<Terc> structure, 
            Dictionary<int, Simc> cities
            ) 
        {
            var removeListFromStructure = new List<Terc>();
            var removeListFromCities = new List<int>();
            foreach (var item in structure)
            {
                foreach (var item2 in cities)
                {
                    if (item.Woj == item2.Value.Woj &&
                        item.Pow == item2.Value.Pow &&
                        item.Gmi == item2.Value.Gmi &&
                        item.Rodz == item2.Value.Rm)
                    {
                        if (item2.Value.Division != null)
                        {
                            item.Division = item2.Value.Division;
                            item.Division.Name = item.Nazwa;
                        }
                        else { throw new NotImplementedException("In Cities shold be defined Division");  }
                        removeListFromStructure.Add(item);
                        removeListFromCities.Add(item2.Key);
                        break;
                    }
                }
            }
            foreach (var item in removeListFromStructure)
            {
                structure.Remove(item);
            }

            foreach (var item in removeListFromCities)
            {
                cities.Remove(item);
            }
            return removeListFromStructure;
        }
        
        private static void CreateDivisionsForCities(Dictionary<int, Simc> cities) 
        {
            foreach (var item in cities) 
            {
                item.Value.Division = new Division 
                { 
                    Id = item.Value.Sym,
                    ParentId = item.Value.SymPod,
                    Name = item.Value.Nazwa,
                    Type = item.Value.Rm,
                };
            }    
        }

        private static void CreateDivisionsForStructure(List<Terc> structure, int counter) 
        {
            foreach (var item in structure) 
            {
                item.Division = new Division 
                { 
                    Id = (int)counter++,
                    ParentId = -1,
                    Name = item.Nazwa,
                    Type = item.Rodz,
                };
            }
        }

        private static void InsertRemovedStructureIntoStructure
            (List<Terc> structure, List<Terc> removed)
        { 
            foreach(var item in removed) 
            { 
                structure.Add(item);
            }
        }

        private static void CreateConnectionsBetweenDivisionsInStructure(List<Terc> structure) 
        {
            CreateConnectionsBetweenWojAndPow(structure);
            CreateConnectionsBetweenPowAndGmi(structure);
        }
        private static void CreateConnectionsBetweenWojAndPow(List<Terc> structure) 
        {
            var woj = structure.Where(x => x.Pow == null && x.Gmi == null).ToList();

            //Connection between WOJ and POW
            foreach (var value in woj)
            {
                var wojPow = structure.Where(x =>
                                x.Woj == value.Woj &&
                                x.Pow != null &&
                                x.Gmi == null).ToList();
                foreach (var item in wojPow)
                {
                    if (item.Division != null && value.Division != null)
                    {
                        item.Division.ParentId = value.Division.Id;
                    }
                    else
                    {
                        throw new NotImplementedException(
                        $"At {value} or {item} not implemented Division");
                    }
                }
            }
        }
        private static void CreateConnectionsBetweenPowAndGmi(List<Terc> structure) 
        {
            //Connection between POW and GMI
            var pow = structure.Where(x => x.Pow != null && x.Gmi == null).ToList();
            foreach (var value in pow)
            {
                var powGmi = structure.Where(x =>
                                x.Woj == value.Woj &&
                                x.Pow == value.Pow &&
                                x.Gmi != null).ToList();
                foreach (var item in powGmi)
                {
                    if (item.Division != null && value.Division != null)
                    {
                        item.Division.ParentId = value.Division.Id;
                    }
                    else
                    {
                        throw new NotImplementedException(
                        $"At {value} or {item} not implemented Division");
                    }
                }
            }
        }

        private static void CreateConnectionsBetweenDivisionsInStructureAndCities
            (
            List<Terc> structure,
            Dictionary<int, Simc> cities
            )
        { 
            var gmi = structure.Where(x => x.Pow != null && x.Gmi != null).ToList();
            foreach (var value in gmi) 
            { 
                var gmiCities = cities.Where(x => 
                            x.Value.Woj == value.Woj  && 
                            x.Value.Pow == value.Pow &&
                            x.Value.Gmi == value.Gmi 
                            ).ToList();
                if (gmiCities.Count() > 0) { 
                    foreach (var item in gmiCities) 
                    {
                        if (item.Value.Division != null && value.Division != null) 
                        {
                            item.Value.Division.ParentId = value.Division.Id;
                        }
                        else { 
                            throw new NotImplementedException(
                            $"DIvisions for {value} and {item} shold be implemented"); 
                        }
                    }
                }
            }
        }

        private static void SetFullStructureIntoDictionary
            (
            List<Terc> structure,
            Dictionary<int, Simc> cities,
             Dictionary<int, Division> dictionary
            )
        { 
            foreach (var value in cities) 
            {
                if (value.Value.Division == null )
                {
                    throw new NotImplementedException($"Division for this value should be implemented {value}");
                }
                if (dictionary.ContainsKey(value.Value.Division.Id)) 
                {
                    throw new Exception("Value is into Dictionary");
                }
                dictionary.Add(value.Value.Division.Id, value.Value.Division);
            }
            foreach (var value in structure)
            {
                if (value.Division == null)
                {
                    throw new NotImplementedException($"Division for this value should be implemented {value}");
                }
                if (dictionary.ContainsKey(value.Division.Id))
                {
                    throw new Exception("Value is into Dictionary");
                }
                dictionary.Add(value.Division.Id, value.Division);
            }
        }
    }
}
