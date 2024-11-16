using System;
using System.Collections.Generic;

namespace ToFu_Photo_Exhibition.Shared.Models;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
