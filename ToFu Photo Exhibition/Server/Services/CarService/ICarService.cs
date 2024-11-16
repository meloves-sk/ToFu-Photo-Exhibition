namespace ToFu_Photo_Exhibition.Server.Services.CarService
{
	public interface ICarService
	{
		Task<ServiceResponse<List<Car>>> GetCarAsync();
	}
}
