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
		public async Task<ActionResult<ServiceResponse<List<Car>>>> GetCar(int categoryId,int manufacturerId,int teamId)
		{
			var response = await _carService.GetCarAsync(categoryId,manufacturerId,teamId);
			return Ok(response);
		}
	}
}
