using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS04.Models
{
    internal class Zebra
    {
        public string Name { get; private set; } = null!;
        public Aviary? Aviary { get; private set; }

        public Zebra(string name) { Name = name; }

        public override string ToString() => $"Zebra: {Name}";
        public ZebraEnum SetToAviary(Aviary aviary)
        {
            if (aviary == null) return ZebraEnum.Null;
            if (Aviary == aviary) return ZebraEnum.UnableSame;
            var privAviary = Aviary;
            Aviary = aviary;
            var message = aviary.SetZebra(this);
            if (message == ZebraEnum.Add)
            {
                if (privAviary != null)
                {
                    privAviary.DeleteZebra(this);
                }
                return message;
            }
            else
            {
                Aviary = privAviary;
                return message;
            }
        }
    }
    class Aviary
    {
        private List<Zebra> _zebraList = new List<Zebra>();
        public string Name { get; private set; } = null!;
        public int MaxLimitOfAnimals { get; private set; }


        public Aviary(string name, int maxLimitOfAnimals)
        {
            Name = name;
            MaxLimitOfAnimals = maxLimitOfAnimals;
        }

        public List<Zebra> GetZebraList() => _zebraList;
        public override string ToString() => $"Aviary: {Name}, Limit: {MaxLimitOfAnimals}";

        public ZebraEnum SetZebra(Zebra zebra)
        {
            if (zebra == null) return ZebraEnum.Null;
            if (_zebraList.Contains(zebra)) return ZebraEnum.Exist;
            if (_zebraList.Count() >= MaxLimitOfAnimals) return ZebraEnum.UnableOverLimit;

            _zebraList.Add(zebra);
            zebra.SetToAviary(this);
            return ZebraEnum.Add;
        }
        public bool DeleteZebra(Zebra zebra)
        {
            if (!_zebraList.Contains(zebra)) return false;
            _zebraList.Remove(zebra);
            return true;
        }
    }
    public enum ZebraEnum { Exist, Null, UnableOverLimit, Add, UnableSame }
}
