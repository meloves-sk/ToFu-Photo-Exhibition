using ToFu_Photo_Exhibition.Shared.Dto.Request;

namespace ToFu_Photo_Exhibition.Server.Services.TeamInformationService
{
    public interface ITeamInformationService
	{
		Task<ServiceResponse<IEnumerable<TeamInformationResponseDto>>> GetTeamInformationsAsync();
		Task<ServiceResponse<bool>> SaveTeamInformation(TeamInformationRequestDto teamInformationRequestDto);
	}
}
