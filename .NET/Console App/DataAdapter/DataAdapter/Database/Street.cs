using System;
using System.Collections.Generic;

namespace DataAdapter.Database;

public partial class Street
{
    public int Id { get; set; }

    public int? TypeId { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual ICollection<Adress> Adresses { get; set; } = new List<Adress>();

    public virtual AdministrativeType? Type { get; set; }

    public virtual ICollection<Division> IdDivisions { get; set; } = new List<Division>();
}
