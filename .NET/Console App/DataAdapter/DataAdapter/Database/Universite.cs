using System;
using System.Collections.Generic;

namespace DataAdapter.Database;

public partial class Universite
{
    public Guid Id { get; set; }

    public DateOnly CreatedDate { get; set; }

    public string Type { get; set; } = null!;

    public DateOnly? LiquidationDate { get; set; }

    public string? Www { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Country { get; set; }

    public string? Wojewodstwo { get; set; }

    public string? Street { get; set; }

    public string? BuildingAndApartment { get; set; }

    public string? ZipCode { get; set; }

    public string? City { get; set; }

    public virtual Company IdNavigation { get; set; } = null!;
}
