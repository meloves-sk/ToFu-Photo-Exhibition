
namespace ToFu_Photo_Exhibition.Server.Services.CarService
{
	public class CarService : ICarService
	{
		private readonly DB _db;
		public CarService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<List<Car>>> GetCarAsync(int categoryId, int manufacturerId, int teamId)
		{
			List<Car> cars = new List<Car>();
			cars.Add(new Car { Id = 0, Name = "すべて" });
			List<Car> getCars = await _db.Cars.Include(a => a.TeamInformation).ToListAsync();
			cars.AddRange(Filter(getCars.Where(a => a.TeamInformation.CategoryId == categoryId).ToList(), manufacturerId, teamId));
			ServiceResponse<List<Car>> response = new ServiceResponse<List<Car>>
			{
				Data = cars,
				Success = true,
				Message = "Success"
			};
			return response;
		}

		private List<Car> Filter(List<Car> cars, int manufacturerId, int teamId)
		{
			if (manufacturerId != 0) return Filter(cars.Where(a => a.TeamInformation.ManufacturerId == manufacturerId).ToList(), 0, teamId);
			if (teamId != 0) return Filter(cars.Where(a => a.TeamInformation.TeamId == teamId).ToList(), manufacturerId, 0);
			return cars;
		}
	}
}
