namespace ToFu_Photo_Exhibition.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoundController : ControllerBase
	{
		private readonly IRoundService _roundService;
		public RoundController(IRoundService roundService)
		{
			_roundService = roundService;
		}
		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Round>>>> GetRound()
		{
			var response = await _roundService.GetRoundsAsync();
			return Ok(response);
		}
	}
}
