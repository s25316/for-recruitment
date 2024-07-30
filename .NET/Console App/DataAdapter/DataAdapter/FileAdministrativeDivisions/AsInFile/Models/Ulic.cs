using DataAdapter.FileAdministrativeDivisions.AsInFile.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAdapter.FileAdministrativeDivisions.AsInFile.Models
{
    public class Ulic
    {
        //Values
        public int SymUl { get; set; }
        public AdministrativeType? Cecha { get; set; } = null!;
        public string Nazwa { get; set; } = null!;

        //Magic numbers for Parsing
        private static readonly int _positionOfSym = 4;
        private static readonly int _positionOfSymUl = 5;
        private static readonly int _positionOfCecha = 6;
        private static readonly int _positionOfName1 = 7;
        private static readonly int _positionOfName2 = 8;

        public static implicit operator Ulic(string text) 
        {
            var list = text.Split(';');
            if (list.Count() != 10) { throw new Exception("Shold be 10 columns in file Ulic, class Ulic"); }

            var sym = int.Parse(list[_positionOfSym]);
            var symUl = int.Parse(list[_positionOfSymUl]);
            var ceha = list[_positionOfCecha];
            var name1 = list[_positionOfName1];
            var name2 = list[_positionOfName2];
            var name = string.IsNullOrEmpty(name2) ? name1 : $"{name1} {name2}";

            new SimcAndUlicColocation(sym, symUl);

            return new Ulic
            {
                SymUl = symUl,
                Cecha = string.IsNullOrEmpty(ceha) ? null : GetAdministrativeType(ceha),
                Nazwa = name,
            };
        }

        private static AdministrativeType GetAdministrativeType(string ceha) 
        {
            return new AdministrativeType().GetAdministrativeType(ceha);            
        }
        public override string ToString() 
            => $"SYMUL {SymUl}, \tCECHA {Cecha}, \tNAZWA {Nazwa}";
    }
}
