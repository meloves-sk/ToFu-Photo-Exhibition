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

		[HttpGet("category/{categoryId}/manufacturer/{manufacturerId}")]
		public async Task<ActionResult<ServiceResponse<IEnumerable<TeamResponseDto>>>> GetTeam(int categoryId, int manufacturerId)
		{
			return Ok(await _teamService.GetTeamsAsync(categoryId, manufacturerId));
		}

		[HttpPost]
		public async Task<ActionResult> RegisterTeam([FromBody] TeamRequestDto teamRequestDto)
		{
			await _teamService.SaveTeam(teamRequestDto);
			return Ok();
		}

		[HttpPut]
		public async Task<ActionResult> UpdateTeam([FromBody] TeamRequestDto teamRequestDto)
		{
			await _teamService.SaveTeam(teamRequestDto);
			return Ok();
		}
	}
}
