namespace ToFu_Photo_Exhibition.Shared.Dto.Request
{
	public class CarRequestDto
	{
		public CarRequestDto(int id, string name, int carNo, int teamInformationId)
		{
			Id = id;
			Name = name;
			CarNo = carNo;
			TeamInformationId = teamInformationId;
		}
		public int Id { get; }
		public string Name { get; }
		public int CarNo { get; }
		public int TeamInformationId { get; }
	}
}
