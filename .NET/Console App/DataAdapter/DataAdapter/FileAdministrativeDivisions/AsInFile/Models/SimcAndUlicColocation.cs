using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAdapter.FileAdministrativeDivisions.AsInFile.Models
{
    public class SimcAndUlicColocation
    {
        public readonly static List<SimcAndUlicColocation> Colocations = new ();
        public int SimcId { get; set; }
        public int UlicId { get; set; }

        public SimcAndUlicColocation(int simcId, int ulicId)
        {
            SimcId = simcId;
            UlicId = ulicId;
            Colocations.Add(this);
        }

        public override string ToString() => $"SimcId {SimcId},\t UlicId {UlicId}";
    }
}
