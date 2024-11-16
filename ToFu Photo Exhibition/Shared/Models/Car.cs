using System;
using System.Collections.Generic;

namespace ToFu_Photo_Exhibition.Shared.Models;

public partial class Car
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CarNo { get; set; }

    public int TeamId { get; set; }

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public virtual Team Team { get; set; } = null!;
}
