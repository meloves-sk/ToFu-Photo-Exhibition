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
		public async Task<ActionResult<ServiceResponse<bool>>> RegisterTeamInformation([FromBody] TeamInformationRequestDto teamInformationRequestDto)
		{
			var response = await _teamInformationService.SaveTeamInformation(teamInformationRequestDto);
			if (!response.Success) return BadRequest(response);
			return Ok(response);
		}

		[HttpPut]
		public async Task<ActionResult<ServiceResponse<bool>>> UpdateTeamInformation([FromBody] TeamInformationRequestDto teamInformationRequestDto)
		{
			var response = await _teamInformationService.SaveTeamInformation(teamInformationRequestDto);
			if (!response.Success) return BadRequest(response);
			return Ok(response);
		}
	}
}
