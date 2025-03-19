namespace ToFu_Photo_Exhibition.Shared.Dto.Request
{
	public class PhotoRequestDto
	{
		public PhotoRequestDto(int id, string description, int roundId, int carId, byte[]? photoData)
		{
			Id = id;
			Description = description;
			RoundId = roundId;
			CarId = carId;
			PhotoData = photoData;
		}
		public int Id { get; }
		public string Description { get; }
		public int RoundId { get; set; }
		public int CarId { get; set; }
		public byte[]? PhotoData { get; }
	}
}
