using ToFu_Photo_Exhibition.Shared.Dto.Request;

namespace ToFu_Photo_Exhibition.Server.Services.TeamService
{
	public interface ITeamService
	{
		Task<ServiceResponse<IEnumerable<TeamResponseDto>>> GetTeamsAsync(int categoryId, int manufacturerId);
		Task SaveTeam(TeamRequestDto teamRequestDto);
	}
}
