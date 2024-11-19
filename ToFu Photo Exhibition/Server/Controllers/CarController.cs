namespace ToFu_Photo_Exhibition.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarController : ControllerBase
	{
		private readonly ICarService _carService;
		public CarController(ICarService carService)
		{
			_carService = carService;
		}

		[HttpGet("category/{categoryId}/manufacturer/{manufacturerId}/team/{teamId}")]
		public async Task<ActionResult<ServiceResponse<IEnumerable<CarResponseDto>>>> GetCar(int categoryId, int manufacturerId, int teamId)
		{
			return Ok(await _carService.GetCarAsync(categoryId, manufacturerId, teamId));
		}

		[HttpPost]
		public async Task<ActionResult> RegisterCar([FromBody] CarRequestDto carRequestDto)
		{
			await _carService.SaveCar(carRequestDto);
			return Ok();
		}

		[HttpPut]
		public async Task<ActionResult> UpdateCar([FromBody] CarRequestDto carRequestDto)
		{
			await _carService.SaveCar(carRequestDto);
			return Ok();
		}
	}
}
