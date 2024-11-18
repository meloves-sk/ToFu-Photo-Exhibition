namespace ToFu_Photo_Exhibition.Server.Services.TeamService
{
	public interface ITeamService
	{
		Task<ServiceResponse<List<Team>>> GetTeamsAsync(int categoryId,int manufacturerId);
		Task SaveTeam(Team team);
	}
}
