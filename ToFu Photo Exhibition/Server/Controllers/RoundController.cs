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

		[HttpGet("category/{categoryId}")]
		public async Task<ActionResult<ServiceResponse<IEnumerable<RoundResponseDto>>>> GetRound(int categoryId)
		{
			return Ok(await _roundService.GetRoundsAsync(categoryId));
		}

		[HttpPost]
		public async Task<ActionResult> RegisterRound([FromBody] RoundRequestDto roundRequestDto)
		{
			await _roundService.SaveRound(roundRequestDto);
			return Ok();
		}

		[HttpPut]
		public async Task<ActionResult> UpdateRound([FromBody] RoundRequestDto roundRequestDto)
		{
			await _roundService.SaveRound(roundRequestDto);
			return Ok();
		}
	}
}
