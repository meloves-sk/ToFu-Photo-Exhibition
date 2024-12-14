namespace ToFu_Photo_Exhibition.Client.Services.CarService
{
	public interface ICarService
	{
		List<CarResponseDto> Cars { get; }
		Task GetFilterCars(int categoryId, int manufacturerId, int teamId);
	}
}
