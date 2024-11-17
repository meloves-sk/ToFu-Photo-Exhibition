namespace ToFu_Photo_Exhibition.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ManufacturerController : ControllerBase
	{
		private readonly IManufacturerService _manufacturerService;
		public ManufacturerController(IManufacturerService manufacturerService)
		{
			_manufacturerService = manufacturerService;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Manufacturer>>>> GetManufacturer(int categoryId)
		{
			var result = await _manufacturerService.GetManufacturersAsync(categoryId);
			return Ok(result);
		}
	}
}
