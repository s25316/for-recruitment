using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MAS03.Models
{
    public enum RulerPersonType { Emperor, King, Feudal }
    internal class RulerPerson
    {
        private int _kingTerritorialUnitsNumber = 15;
        private int _emperorTerritorialUnitsNumber = 50;
        private int _territorialUnitsNumber;
        public int TerritorialUnitsNumber
        {
            get { return _territorialUnitsNumber; }
            set
            {
                _territorialUnitsNumber = value;
                if (value < _kingTerritorialUnitsNumber) Ruler = RulerPersonType.Feudal;
                else if (value > _kingTerritorialUnitsNumber && value < _emperorTerritorialUnitsNumber)
                {
                    _kingdomsNumber = (int)(value / _kingTerritorialUnitsNumber);
                    Ruler = RulerPersonType.King;
                }
                else 
                {
                    _kingdomsNumber = (int)(value / _kingTerritorialUnitsNumber);
                    _empiresNumber = (int)(value / _emperorTerritorialUnitsNumber);
                    Ruler = RulerPersonType.Emperor;
                }
            }
        }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public RulerPersonType Ruler { get; private set; }

        //King Part 
        private int _kingdomsNumber;
        public int KingdomsNumber { 
            get 
            { 
                if (Ruler == RulerPersonType.King || Ruler == RulerPersonType.Emperor) return _kingdomsNumber;
                else throw new Exception($"Information only for {RulerPersonType.King}");
            }  
        }
        private int _crown;
        public int Crown
        {
            get
            {
                if (Ruler == RulerPersonType.King || Ruler == RulerPersonType.Emperor) return _crown;
                else throw new Exception($"Information only for {RulerPersonType.King}");
            }
            set 
            {
                if (Ruler == RulerPersonType.King || Ruler == RulerPersonType.Emperor) _crown = value;
                else throw new Exception($"Information only for {RulerPersonType.King}");
            }
        }

        // Empier Part
        private int _empiresNumber;
        public int EmpiresNumber
        {
            get
            {
                if (Ruler == RulerPersonType.Emperor) return _empiresNumber;
                else throw new Exception($"Information only for {RulerPersonType.Emperor}");
            }
        }
        private int _coinsNumberWithEmperor;
        public int CoinsNumberWithEmperor { 
            get 
            {
                if (Ruler == RulerPersonType.Emperor) return _coinsNumberWithEmperor;
                else throw new Exception($"Information only for {RulerPersonType.Emperor}");
            } 
            set 
            {
                if (Ruler == RulerPersonType.Emperor) _empiresNumber = value;
                else throw new Exception($"Information only for {RulerPersonType.Emperor}");
            }
        }

        public override string ToString()
        {
            var kingText = (Ruler == RulerPersonType.King || Ruler == RulerPersonType.Emperor) ? $"\nKingdoms - {_kingdomsNumber}, Krown = {_crown}" : "";
            var emperorText = (Ruler == RulerPersonType.Emperor) ? $"\nKingdoms - {_empiresNumber}, Coins Number With Emperor = {_coinsNumberWithEmperor}" : "";
            return $"Name - {FirstName}, Surname - {LastName},Title - {Ruler}, Territorial Units - {_territorialUnitsNumber} {kingText}{emperorText}";
        }
    }
}
