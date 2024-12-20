namespace ToFu_Photo_Exhibition.Shared.Dto.Response
{
	public class TeamResponseDto
	{
		public TeamResponseDto(int id, string name)
		{
			Id = id;
			Name = name;
		}
		public int Id { get; }

		public string Name { get; }
	}
}
