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
		public async Task<ActionResult<ServiceResponse<IEnumerable<CarResponseDto>>>> GetFilterCars(int categoryId, int manufacturerId, int teamId)
		{
			return Ok(await _carService.GetFilterCarsAsync(categoryId, manufacturerId, teamId));
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<bool>>> RegisterCar([FromBody] CarRequestDto carRequestDto)
		{
			var response = await _carService.SaveCar(carRequestDto);
			if (!response.Success)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

		[HttpPut]
		public async Task<ActionResult<ServiceResponse<bool>>> UpdateCar([FromBody] CarRequestDto carRequestDto)
		{
			var response = await _carService.SaveCar(carRequestDto);
			if (!response.Success)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

		[HttpDelete("{carId}")]
		public async Task<ActionResult<ServiceResponse<bool>>> DeleteCar(int carId)
		{
			var response = await _carService.DeleteCar(carId);
			if (!response.Success)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}
	}
}
