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
		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Car>>>> GetCar()
		{
			var response = await _carService.GetCarAsync();
			return Ok(response);
		}
	}
}
