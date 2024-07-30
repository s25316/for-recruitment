using DataAdapter.FileAdministrativeDivisions.AsInFile.Types;
using DataAdapter.FileAdministrativeDivisions.MyOwn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAdapter.FileAdministrativeDivisions.AsInFile.Models
{
    public class Terc
    {
        //Values
        public int Woj { get; set; } = -1; //województwo
        public int? Pow { get; set; } = null; //powiat, miasto na prawach powiatu
        public int? Gmi { get; set; } = null; // RODZ
        public AdministrativeType Rodz { get; set; } = null!;
        public string Nazwa { get; set; } = null!;
        //My own Part
        public Division? Division { get; set; } = null;

        //Magic numbers for Parsing
        private static readonly int _positionOfWOJ = 0;
        private static readonly int _positionOfPOW = 1;
        private static readonly int _positionOfGMI = 2;
        private static readonly int _positionOfRODZ = 3;
        private static readonly int _positionOfNAZWA = 4;
        private static readonly int _positionOfNAZWADOD = 5;

        public static implicit operator Terc(string text) 
        {
            var list = text.Split(';');
            if (list.Length != 7) { throw new Exception("Ucorrect data shold be 7 columns"); }

            var woj = int.Parse(list[_positionOfWOJ]);
            int? pow = string.IsNullOrEmpty(list[_positionOfPOW]) ?
                        null : int.Parse(list[_positionOfPOW]);
            int? gmi = string.IsNullOrEmpty(list[_positionOfGMI]) ?
                        null : int.Parse(list[_positionOfGMI]);
            var rodz = GetAdministrativeType(list[_positionOfRODZ], list[_positionOfNAZWADOD]);
            var nazwa = list[_positionOfNAZWA];

            return new Terc
            {
                Woj = woj,
                Pow = pow,
                Gmi = gmi,
                Rodz = rodz,
                Nazwa = nazwa,
            };
        }

        private static AdministrativeType GetAdministrativeType(string rodz, string nazawaDod)
        {
            var list = new AdministrativeType();

            string? rodzName = null;
            if (!string.IsNullOrEmpty(rodz))
            {                
                var rodzInt = int.Parse(rodz);
                switch (rodzInt)
                {
                    case 1: rodzName = "gmina miejska"; break;
                    case 2: rodzName = "gmina wiejska"; break;
                    case 3: rodzName = "gmina miejsko - wiejska"; break;
                    case 5: rodzName = "obszar wiejski"; break;
                    case 4: rodzName = "miasto"; break;
                    case 8: rodzName = "dzielnica"; break;
                    case 9: rodzName = "delegatura"; break;
                    default: throw new NotImplementedException($"undefined value of Rodz in file RODZ {rodzInt}");
                }
                return list.GetAdministrativeType( rodzName );
            }
            /*switch (nazawaDod) 
            {
                case "województwo": break;
                case "powiat": break;
                case "miasto na prawach powiatu": break;
                case "miasto stołeczne, na prawach powiatu": break;
            }*/
            rodzName = nazawaDod;
            if (nazawaDod == "miasto stołeczne, na prawach powiatu") 
            {
                rodzName = "miasto na prawach powiatu";
            }
            return list.GetAdministrativeType(rodzName);
            //throw new Exception($"Not exist option in GetAdministrativeType class Terc: {rodz} {nazawaDod}");
        }

        public override string ToString()
        => $"WOJ {Woj},\t POW {Pow},\t GMI {Gmi},\t RODZ {Rodz},\t NAZWA {Nazwa}";
    }
}
