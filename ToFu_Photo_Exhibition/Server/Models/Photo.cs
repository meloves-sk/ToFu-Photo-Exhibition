namespace ToFu_Photo_Exhibition.Server.Models;
public partial class Photo
{
    public int Id { get; set; }

    public string FilePath { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int RoundId { get; set; }

    public int CarId { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Round Round { get; set; } = null!;
}
