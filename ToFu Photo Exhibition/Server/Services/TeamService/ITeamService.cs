using System.Net.NetworkInformation;
using ToFu_Photo_Exhibition.Shared.Dto.Request;

namespace ToFu_Photo_Exhibition.Server.Services.TeamService
{
	public interface ITeamService
	{
		Task<ServiceResponse<IEnumerable<TeamResponseDto>>> GetTeamsAsync();
		Task<ServiceResponse<IEnumerable<TeamResponseDto>>> GetFilterTeamsAsync(int categoryId, int manufacturerId);
		Task<ServiceResponse<bool>> SaveTeam(TeamRequestDto teamRequestDto);
	}
}
