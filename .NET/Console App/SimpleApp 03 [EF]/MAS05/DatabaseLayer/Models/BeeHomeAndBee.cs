using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS05.DatabaseLayer.Models
{
    internal class BeeHomeAndBee
    {
        public int IdBee { get; set; }
        public int IdBeeHome { get; set; }
        public DateOnly DateFrom { get; set; }
        public DateOnly? DateTo { get; set; } = null;

        public virtual Bee Bee { get; set; } = null!;
        public virtual BeeHome BeeHome { get; set; } = null!;

    }
}
