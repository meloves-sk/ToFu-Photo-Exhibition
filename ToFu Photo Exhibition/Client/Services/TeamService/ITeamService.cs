namespace ToFu_Photo_Exhibition.Client.Services.TeamService
{
	public interface ITeamService
	{
		List<TeamResponseDto> Teams { get; }
		bool IsSearch { get; set; }
		Task GetFilterTeams(int categoryId, int manufacturerId);
	}
}
