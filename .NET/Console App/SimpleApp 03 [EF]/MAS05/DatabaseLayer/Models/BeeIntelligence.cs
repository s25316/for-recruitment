using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS05.DatabaseLayer.Models
{
    internal class BeeIntelligence
    {
        public int IdBee { get; set; }
        public int Distance { get; set; }

        public virtual Bee Bee { get; set; } = null!;
    }
}
