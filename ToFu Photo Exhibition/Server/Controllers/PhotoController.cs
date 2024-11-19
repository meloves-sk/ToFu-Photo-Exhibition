namespace ToFu_Photo_Exhibition.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PhotoController : ControllerBase
	{
		private readonly IPhotoService _photoService;
		public PhotoController(IPhotoService photoService)
		{
			_photoService = photoService;
		}

		[HttpGet("category/{categoryId}/manufacturer/{manufacturerId}/team/{teamId}/car/{carId}")]
		public async Task<ActionResult<ServiceResponse<IEnumerable<PhotoResponseDto>>>> GetPhotos(int categoryId, int roundId, int manufacturerId, int teamId, int carId)
		{
			return Ok(await _photoService.GetPhotosAsync(categoryId, roundId, manufacturerId, teamId, carId));
		}

	}
}
