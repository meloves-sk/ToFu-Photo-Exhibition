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
		public async Task<ActionResult<ServiceResponse<IEnumerable<TeamInformationResponseDto>>>> GetTeamInformation()
		{
			return Ok(await _teamInformationService.GetTeamInformationsAsync());
		}

		[HttpPost]
		public async Task<ActionResult> RegisterTeamInformation([FromBody] TeamInformationRequestDto teamInformationRequestDto)
		{
			await _teamInformationService.SaveTeamInformation(teamInformationRequestDto);
			return Ok();
		}

		[HttpPut]
		public async Task<ActionResult> UpdateTeamInformation([FromBody] TeamInformationRequestDto teamInformationRequestDto)
		{
			await _teamInformationService.SaveTeamInformation(teamInformationRequestDto);
			return Ok();
		}
	}
}
