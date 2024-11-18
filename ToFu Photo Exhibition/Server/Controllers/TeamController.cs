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
		public async Task<ActionResult<ServiceResponse<List<Team>>>> GetTeam(int categoryId, int manufacturerId)
		{
			var result = await _teamService.GetTeamsAsync(categoryId, manufacturerId);
			return Ok(result);
		}
		[HttpPost]
		public async Task<ActionResult> RegisterTeam([FromBody] Team team)
		{
			await _teamService.SaveTeam(team);
			return Ok();
		}
		[HttpPut]
		public async Task<ActionResult> UpdateTeam([FromBody] Team team)
		{
			await _teamService.SaveTeam(team);
			return Ok();
		}
	}
}
