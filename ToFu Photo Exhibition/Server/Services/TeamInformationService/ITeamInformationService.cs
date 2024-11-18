namespace ToFu_Photo_Exhibition.Server.Services.TeamInformationService
{
	public interface ITeamInformationService
	{
		Task<ServiceResponse<List<TeamInformation>>> GetTeamInformationsAsync();
		Task SaveTeamInformation(TeamInformation teamInformation);
	}
}
