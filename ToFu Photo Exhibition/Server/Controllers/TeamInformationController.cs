using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToFu_Photo_Exhibition.Server.Services.TeamInformationService;

namespace ToFu_Photo_Exhibition.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeamInformationController : ControllerBase
	{
		private readonly ITeamInformationService _teamInformationService;
		public TeamInformationController(ITeamInformationService teamInformationService)
		{
			_teamInformationService = teamInformationService;
		}
		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<TeamInformation>>>> GetTeamInformation()
		{
			var response = await _teamInformationService.GetTeamInformationsAsync();
			return Ok(response);
		}
		[HttpPost]
		public async Task<ActionResult> RegisterTeamInformation([FromBody] TeamInformation teamInformation)
		{
			await _teamInformationService.SaveTeamInformation(teamInformation);
			return Ok();
		}
		[HttpPut]
		public async Task<ActionResult> UpdateTeamInformation([FromBody] TeamInformation teamInformation)
		{
			await _teamInformationService.SaveTeamInformation(teamInformation);
			return Ok();
		}
	}
}
