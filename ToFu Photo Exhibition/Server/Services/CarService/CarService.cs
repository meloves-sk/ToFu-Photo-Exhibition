
namespace ToFu_Photo_Exhibition.Server.Services.CarService
{
	public class CarService : ICarService
	{
		private readonly DB _db;
		public CarService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<List<Car>>> GetCarAsync()
		{
			List<Car> cars = await _db.Cars.ToListAsync();
			ServiceResponse<List<Car>> response = new ServiceResponse<List<Car>>
			{
				Data = cars,
				Success = true,
				Message = "Success"
			};
			return response;
		}
	}
}
