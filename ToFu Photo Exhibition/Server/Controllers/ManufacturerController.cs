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

		[HttpGet("category/{categoryId}")]
		public async Task<ActionResult<ServiceResponse<List<Manufacturer>>>> GetManufacturer(int categoryId)
		{
			var result = await _manufacturerService.GetManufacturersAsync(categoryId);
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult> RegisterManufacturer([FromBody] Manufacturer manufacturer)
		{
			await _manufacturerService.SaveManufacturer(manufacturer);
			return Ok();
		}

		[HttpPut]
		public async Task<ActionResult> UpdateManufacturer([FromBody] Manufacturer manufacturer)
		{
			await _manufacturerService.SaveManufacturer(manufacturer);
			return Ok();
		}
	}
}
