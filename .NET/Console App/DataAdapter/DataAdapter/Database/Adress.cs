using System;
using System.Collections.Generic;

namespace DataAdapter.Database;

public partial class Adress
{
    public int Id { get; set; }

    public int DivisionId { get; set; }

    public int StreetId { get; set; }

    public string HourseAndApratment { get; set; } = null!;

    public virtual Division Division { get; set; } = null!;

    public virtual Street Street { get; set; } = null!;
}
