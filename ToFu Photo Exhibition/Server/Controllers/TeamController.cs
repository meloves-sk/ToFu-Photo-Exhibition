namespace ToFu_Photo_Exhibition.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeamController : ControllerBase
	{
		private readonly ITeamService _teamService;
		public TeamController(ITeamService teamService)
		{
			_teamService = teamService;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<IEnumerable<TeamResponseDto>>>> GetTeam()
		{
			return Ok(await _teamService.GetTeamsAsync());
		}

		[HttpGet("category/{categoryId}/manufacturer/{manufacturerId}")]
		public async Task<ActionResult<ServiceResponse<IEnumerable<TeamResponseDto>>>> GetTeam(int categoryId, int manufacturerId)
		{
			return Ok(await _teamService.GetFilterTeamsAsync(categoryId, manufacturerId));
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<bool>>> RegisterTeam([FromBody] TeamRequestDto teamRequestDto)
		{
			var response = await _teamService.SaveTeam(teamRequestDto);
			if (!response.Success) return BadRequest(response);
			return Ok(response);
		}

		[HttpPut]
		public async Task<ActionResult<ServiceResponse<bool>>> UpdateTeam([FromBody] TeamRequestDto teamRequestDto)
		{
			var response = await _teamService.SaveTeam(teamRequestDto);
			if (!response.Success) return BadRequest(response);
			return Ok(response);
		}
	}
}
