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
		public async Task<ActionResult<ServiceResponse<List<Team>>>> GetTeam()
		{
			var result = await _teamService.GetTeamsAsync();
			return Ok(result);
		}
	}
}
