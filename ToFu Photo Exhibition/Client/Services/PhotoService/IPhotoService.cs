namespace ToFu_Photo_Exhibition.Client.Services.PhotoService
{
	public interface IPhotoService
	{
		List<PhotoResponseDto> Photos { get; }
		Task GetFilterPhotos(int categoryId, int roundId, int manufacturerId, int teamId, int carId);
	}
}
