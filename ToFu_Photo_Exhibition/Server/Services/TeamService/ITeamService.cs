namespace ToFu_Photo_Exhibition.Server.Services.TeamService
{
	public interface ITeamService
	{
		Task<ServiceResponse<IEnumerable<TeamResponseDto>>> GetFilterTeamsAsync(int categoryId, int manufacturerId);
		Task<ServiceResponse<bool>> SaveTeam(TeamRequestDto teamRequestDto);
		Task<ServiceResponse<bool>> DeleteTeam(int teamId);
	}
}
