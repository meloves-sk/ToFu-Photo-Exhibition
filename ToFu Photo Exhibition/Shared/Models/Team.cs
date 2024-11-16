using System;
using System.Collections.Generic;

namespace ToFu_Photo_Exhibition.Shared.Models;

public partial class Team
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ManufacturerId { get; set; }

    public int CategoryId { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual Category Category { get; set; } = null!;

    public virtual Manufacturer Manufacturer { get; set; } = null!;
}
