using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS03.Models
{
    internal abstract class Animal
    {
        public string Name { get; private set; } = null!;
        public int LimbsNumber { get; protected set; }
        public bool IsFyable { get; private set; }
        public bool IsSwimable { get; private set; }

        public Animal (string name, bool isFyable, bool isSwimable)
        {
            Name = name;
            IsFyable = isFyable;
            IsSwimable = isSwimable;
        }

        public abstract string Description();
    }
    class Bird : Animal
    {
        public int WingsNumber { get; private set; }
        public int LegsNumber { get; private set; }

        public Bird(string name, bool isFyable, bool isSwimable, int wingsNumber, int legsNumber) : base(name, isFyable, isSwimable)
        {
            if (wingsNumber > 0) WingsNumber = wingsNumber;

            if (legsNumber > 0) LegsNumber = legsNumber;

            base.LimbsNumber = WingsNumber + LegsNumber;
        }

        public override string Description()
        {
            var wingsText = (WingsNumber > 0 ? $"\nWings - {WingsNumber}" : "");
            var legsText = (LegsNumber > 0 ? $"\nLegs - {LegsNumber}" : "");
            var limbsText = $"Limbs - {base.LimbsNumber}{wingsText}{legsText}\n====================================";
            return $"[{this.GetType().Name}]: Name - {base.Name} \n Is Fyable - {base.IsFyable}, Is Swimable - {base.IsSwimable}\n{limbsText}";
        }
    }

    class Mammal : Animal
    {
        public int WingsNumber { get; private set; } 
        public int PectoralFin {  get; private set; } 
        public int CaudalFin { get; private set; }

        public Mammal(string name, bool isFyable, bool isSwimable,
            int wingsNumber, int pectoralFin, int caudalFin, int otherLimbs) : base(name, isFyable, isSwimable)
        {
            if (wingsNumber > 0) WingsNumber = wingsNumber; 

            if (pectoralFin > 0) PectoralFin = pectoralFin;

            if (caudalFin > 0) CaudalFin = caudalFin;

            base.LimbsNumber = WingsNumber + PectoralFin + CaudalFin + (otherLimbs > 0? otherLimbs : 0);            
        }

        public override string Description()
        {
            var wingsText = (WingsNumber > 0 ? $"\nWings - {WingsNumber}" : "");
            var pectoralText = (PectoralFin > 0 ? $"\nPectoral Fins - {PectoralFin}" : "");
            var caudalText = (CaudalFin > 0 ? $"\nCaudal Fins - {CaudalFin}" : "");
            var limbsText = $"Limbs - {base.LimbsNumber}{wingsText}{pectoralText}{caudalText}\n====================================";
            return $"[{this.GetType().Name}]: Name - {base.Name} \n Is Fyable - {base.IsFyable}, Is Swimable - {base.IsSwimable}\n{limbsText}";
        }
    }
}
