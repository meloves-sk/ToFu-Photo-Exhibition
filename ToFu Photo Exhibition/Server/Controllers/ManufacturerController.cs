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
		public async Task<ActionResult<ServiceResponse<IEnumerable<ManufacturerResponseDto>>>> GetManufacturer(int categoryId)
		{
			return Ok(await _manufacturerService.GetManufacturersAsync(categoryId));
		}

		[HttpPost]
		public async Task<ActionResult> RegisterManufacturer([FromBody] ManufacturerRequestDto manufacturerRequestDto)
		{
			await _manufacturerService.SaveManufacturer(manufacturerRequestDto);
			return Ok();
		}

		[HttpPut]
		public async Task<ActionResult> UpdateManufacturer([FromBody] ManufacturerRequestDto manufacturerRequestDto)
		{
			await _manufacturerService.SaveManufacturer(manufacturerRequestDto);
			return Ok();
		}
	}
}
