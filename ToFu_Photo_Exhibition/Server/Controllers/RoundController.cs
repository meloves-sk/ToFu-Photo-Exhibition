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
		public async Task<ActionResult<ServiceResponse<IEnumerable<RoundResponseDto>>>> GetFilterRounds(int categoryId)
		{
			return Ok(await _roundService.GetFilterRoundsAsync(categoryId));
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<bool>>> RegisterRound([FromBody] RoundRequestDto roundRequestDto)
		{
			var response = await _roundService.SaveRound(roundRequestDto);
			if (!response.Success) return BadRequest(response);
			return Ok(response);
		}

		[HttpPut]
		public async Task<ActionResult<ServiceResponse<bool>>> UpdateRound([FromBody] RoundRequestDto roundRequestDto)
		{
			var response = await _roundService.SaveRound(roundRequestDto);
			if (!response.Success) return BadRequest(response);
			return Ok(response);
		}

		[HttpDelete("{roundId}")]
		public async Task<ActionResult<ServiceResponse<bool>>> DeleteRound(int roundId)
		{
			var response = await _roundService.DeleteRound(roundId);
			if (!response.Success)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}
	}
}
