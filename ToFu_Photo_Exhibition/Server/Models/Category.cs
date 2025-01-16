namespace ToFu_Photo_Exhibition.Server.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Round> Rounds { get; set; } = new List<Round>();

    public virtual ICollection<TeamInformation> TeamInformations { get; set; } = new List<TeamInformation>();
}
