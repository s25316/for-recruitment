using System;
using System.Collections.Generic;

namespace DataAdapter.Database;

public partial class Company
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Regon { get; set; }

    public string? Nip { get; set; }

    public bool IsOurClient { get; set; }

    public string? Email { get; set; }

    public virtual Universite? Universite { get; set; }
}
