namespace ToFu_Photo_Exhibition.Server.Models
{
	public partial class TeamInformation
	{
		public int Id { get; set; }

		public int TeamId { get; set; }

		public int ManufacturerId { get; set; }

		public int CategoryId { get; set; }

		public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

		public virtual Category Category { get; set; } = null!;

		public virtual Manufacturer Manufacturer { get; set; } = null!;

		public virtual Team Team { get; set; } = null!;
	}
}