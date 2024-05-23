using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS05.DatabaseLayer.Models
{
    internal class Bee
    {
        public int IdBee { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly BirthDate { get; set; } //= DateOnly.FromDateTime(DateTime.Now);
        public DateOnly? DateDeath { get; set; } = null; //= DateOnly.FromDateTime(DateTime.Now);

        public virtual ICollection<BeeHomeAndBee> BeeHomeAndBees { get; set; } = new List<BeeHomeAndBee>();

        public virtual BeeSecurity? BeeSecurity { get; set; } = null;
        public virtual BeeIntelligence? BeeIntelligence { get; set; } = null;
    }
}
