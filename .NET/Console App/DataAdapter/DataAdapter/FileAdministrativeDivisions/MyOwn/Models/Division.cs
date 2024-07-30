using DataAdapter.FileAdministrativeDivisions.AsInFile.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAdapter.FileAdministrativeDivisions.MyOwn.Models
{
    public class Division
    {
        public int Id { get; set; } = -1;
        public int ParentId { get; set; } = -1;
        public string Name { get; set; } =  null!;
        public AdministrativeType Type { get; set; } = null!;
        public ICollection<Division> Childrens { get; } = new List<Division>();

        public override string ToString()
            => $"[{Id}] \t{ParentId} \t{Name} \t({Type})";
    }
}
