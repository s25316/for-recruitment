using System;
using System.Collections.Generic;

namespace DataAdapter.Database;

public partial class AdministrativeType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();

    public virtual ICollection<Street> Streets { get; set; } = new List<Street>();
}
