namespace ToFu_Photo_Exhibition.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[RequestSizeLimit(52428800)]
	public class PhotoController : ControllerBase
	{
		private readonly IPhotoService _photoService;
		public PhotoController(IPhotoService photoService)
		{
			_photoService = photoService;
		}

		[HttpGet("category/{categoryId}/round/{roundId}/manufacturer/{manufacturerId}/team/{teamId}/car/{carId}")]
		public async Task<ActionResult<ServiceResponse<IEnumerable<PhotoResponseDto>>>> GetPhotos(int categoryId, int roundId, int manufacturerId, int teamId, int carId)
		{
			return Ok(await _photoService.GetPhotosAsync(categoryId, roundId, manufacturerId, teamId, carId));
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<bool>>> AddPhoto([FromBody] PhotoRequestDto request)
		{
			var response = await _photoService.SavePhoto(request);
			if (!response.Success)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

		[HttpPut]
		public async Task<ActionResult<ServiceResponse<bool>>> UpdatePhoto([FromBody] PhotoRequestDto request)
		{
			var response = await _photoService.SavePhoto(request);
			if (!response.Success)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

		[HttpDelete("{photoId}")]
		public async Task<ActionResult<ServiceResponse<bool>>> DeletePhoto(int photoId)
		{
			return Ok(await _photoService.DeletePhoto(photoId));
		}

	}
}
