namespace ToFu_Photo_Exhibition.Shared.Dto.Response
{
	public class ManufacturerResponseDto
	{
		public ManufacturerResponseDto(int id, string name)
		{
			Id = id;
			Name = name;
		}
		public int Id { get; }

		public string Name { get; }

	}
}
