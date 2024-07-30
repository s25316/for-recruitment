using System;
using System.Collections.Generic;

namespace DataAdapter.Database;

public partial class Division
{
    public int Id { get; set; }

    public int ParentId { get; set; }

    public string Name { get; set; } = null!;

    public int TypeId { get; set; }

    public virtual ICollection<Adress> Adresses { get; set; } = new List<Adress>();

    public virtual AdministrativeType Type { get; set; } = null!;

    public virtual ICollection<Street> IdStreets { get; set; } = new List<Street>();
}
