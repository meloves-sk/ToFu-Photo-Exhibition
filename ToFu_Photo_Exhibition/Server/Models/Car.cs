namespace ToFu_Photo_Exhibition.Server.Models;

public partial class Car
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CarNo { get; set; }

    public int TeamInformationId { get; set; }

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public virtual TeamInformation TeamInformation { get; set; } = null!;
}
