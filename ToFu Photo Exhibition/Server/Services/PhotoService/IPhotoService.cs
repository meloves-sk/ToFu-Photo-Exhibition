namespace ToFu_Photo_Exhibition.Server.Services.PhotoService
{
	public interface IPhotoService
	{
		Task<ServiceResponse<List<Photo>>> GetPhotosAsync(int categoryId, int roundId, int manufacturerId, int teamId, int carId);
	}
}
