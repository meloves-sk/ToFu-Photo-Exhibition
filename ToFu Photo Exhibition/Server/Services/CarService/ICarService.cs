namespace ToFu_Photo_Exhibition.Server.Services.CarService
{
	public interface ICarService
	{
		Task<ServiceResponse<List<Car>>> GetCarAsync(int categoryId, int manufacturerId, int teamId);
		Task SaveCar(Car car);
	}
}
