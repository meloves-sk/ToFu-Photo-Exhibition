namespace ToFu_Photo_Exhibition.Client.Services.TeamService
{
	public interface ITeamService
	{
		List<TeamResponseDto> Teams { get; }
		Task GetFilterTeams(int categoryId, int manufacturerId);
	}
}
