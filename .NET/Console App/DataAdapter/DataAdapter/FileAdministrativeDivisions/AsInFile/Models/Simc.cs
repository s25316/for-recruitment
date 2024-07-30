using DataAdapter.FileAdministrativeDivisions.AsInFile.Types;
using DataAdapter.FileAdministrativeDivisions.MyOwn.Models;

namespace DataAdapter.FileAdministrativeDivisions.AsInFile.Models
{
    public class Simc
    {
        public int Woj { get; set; } 
        public int Pow { get; set; } 
        public int Gmi { get; set; }
        public int Sym { get; set; } 
        public int SymPod { get; set; } = -1;
        public AdministrativeType Rm { get; set; } = null!;
        public string Nazwa { get; set; } = null!;
        //My own Part
        public Division? Division { get; set; } = null;

        //Magic numbers
        private static readonly int _positionOfWOJ = 0;
        private static readonly int _positionOfPOW = 1;
        private static readonly int _positionOfGMI = 2;
        //private static readonly int _positionOfRODZ = 3;
        private static readonly int _positionOfRM = 4;
        private static readonly int _positionOfNAZWA = 6;
        private static readonly int _positionOfSYM = 7;
        private static readonly int _positionOfSYMPOD = 8;

        public static implicit operator Simc(string text) 
        {
            var list = text.Split(';');
            if (list.Count() != 10) { throw new Exception("Shold be 10 columns in SIMC, Class Simc"); }

            var woj = int.Parse(list[_positionOfWOJ]);
            var pow = int.Parse(list[_positionOfPOW]);
            var gmi = int.Parse(list[_positionOfGMI]);
            //var rodz = int.Parse(list[_positionOfRODZ]);

            var rm = int.Parse(list[_positionOfRM]);
            var nazwa = list[_positionOfNAZWA];
            var sym = int.Parse(list[_positionOfSYM]);
            var symPod = int.Parse(list[_positionOfSYMPOD]);

            return new Simc
            {
                Woj = woj,
                Pow = pow,
                Gmi = gmi,
                Sym = sym,
                SymPod = sym == symPod ? -1 : symPod,
                Nazwa = nazwa,
                Rm = GetRmById(rm),
            };
        }

        private static AdministrativeType GetRmById(int rm) 
        {
            var list = new AdministrativeType();
            string type = "";
            switch (rm) 
            {
                case 0: type = "część miejscowości"; break;
                case 1: type = "wieś"; break;
                case 2: type = "kolonia"; break;
                case 3: type = "przysiółek"; break;
                case 4: type = "osada"; break;
                case 5: type = "osada leśna"; break;
                case 6: type = "osiedle"; break;// not exist 
                case 7: type = "schronisko turystyczne"; break;
                case 95: type = "dzielnica"; break;
                case 96: type = "miasto"; break;
                case 98: type = "delegatura"; break;
                case 99: type = "część miasta"; break;
                default: break;
            }
            return list.GetAdministrativeType(type);
        }

        public override string ToString()
            => $"SYM {Sym},\t SYMPOD {SymPod},\tWoj {Woj},\tPow {Pow},\tGmi {Gmi},\tRM {Rm},\tNAZWA {Nazwa} ";
    }
}
