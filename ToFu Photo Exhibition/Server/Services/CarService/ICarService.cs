namespace ToFu_Photo_Exhibition.Server.Services.CarService
{
	public interface ICarService
	{
		Task<ServiceResponse<IEnumerable<CarResponseDto>>> GetFilterCarsAsync(int categoryId, int manufacturerId, int teamId);
		Task<ServiceResponse<bool>> SaveCar(CarRequestDto carRequestDto);
		Task<ServiceResponse<bool>> DeleteCar(int carId);
	}
}
