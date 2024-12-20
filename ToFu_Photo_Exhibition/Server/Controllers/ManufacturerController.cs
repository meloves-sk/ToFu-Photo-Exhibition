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
		public async Task<ActionResult<ServiceResponse<IEnumerable<ManufacturerResponseDto>>>> GetFilterManufacturers(int categoryId)
		{
			return Ok(await _manufacturerService.GetFilterManufacturersAsync(categoryId));
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<bool>>> RegisterManufacturer([FromBody] ManufacturerRequestDto manufacturerRequestDto)
		{
			var response = await _manufacturerService.SaveManufacturer(manufacturerRequestDto);
			if (!response.Success)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

		[HttpPut]
		public async Task<ActionResult<ServiceResponse<bool>>> UpdateManufacturer([FromBody] ManufacturerRequestDto manufacturerRequestDto)
		{
			var response = await _manufacturerService.SaveManufacturer(manufacturerRequestDto);
			if (!response.Success)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

		[HttpDelete("{manufacturerId}")]
		public async Task<ActionResult<ServiceResponse<bool>>> DeleteManufacturer(int manufacturerId)
		{
			var response = await _manufacturerService.DeleteManufacturer(manufacturerId);
			if (!response.Success)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

	}
}
