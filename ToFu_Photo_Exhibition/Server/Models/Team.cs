namespace ToFu_Photo_Exhibition.Server.Models
{
	public partial class Team
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public virtual ICollection<TeamInformation> TeamInformations { get; set; } = new List<TeamInformation>();
	}
}