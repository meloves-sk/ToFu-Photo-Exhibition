
using ToFu_Photo_Exhibition.Shared.Dto.Request;

namespace ToFu_Photo_Exhibition.Server.Services.CarService
{
	public class CarService : ICarService
	{
		private readonly DB _db;
		public CarService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<IEnumerable<CarResponseDto>>> GetCarAsync(int categoryId, int manufacturerId, int teamId)
		{
			List<CarResponseDto> cars = new List<CarResponseDto>();
			cars.Add(new CarResponseDto(0, "すべて", 0, 0, string.Empty, string.Empty, string.Empty));
			Filter(await _db.Cars.Include(a => a.TeamInformation).ThenInclude(a => a.Team).Include(a => a.TeamInformation).ThenInclude(a => a.Manufacturer).Include(a => a.TeamInformation).ThenInclude(a => a.Category).Where(a => a.TeamInformation.CategoryId == categoryId).ToListAsync(), manufacturerId, teamId).ForEach(a =>
			{
				cars.Add(new CarResponseDto(a.Id, a.Name, a.CarNo, a.TeamInformationId, a.TeamInformation.Team.Name, a.TeamInformation.Manufacturer.Name, a.TeamInformation.Category.Name));
			});
			return new ServiceResponse<IEnumerable<CarResponseDto>>
			{
				Data = cars,
				Success = true,
				Message = "Success"
			};
		}

		public async Task SaveCar(CarRequestDto carRequestDto)
		{
			Car car = await _db.Cars.FindAsync(carRequestDto.Id) ?? new Car();
			car.Name = carRequestDto.Name;
			car.CarNo = carRequestDto.CarNo;
			car.TeamInformationId = carRequestDto.TeamInformationId;
			if (car.Id == 0) _db.Cars.Add(car);
			await _db.SaveChangesAsync();
		}

		private List<Car> Filter(List<Car> cars, int manufacturerId, int teamId)
		{
			if (manufacturerId != 0) return Filter(cars.Where(a => a.TeamInformation.ManufacturerId == manufacturerId).ToList(), 0, teamId);
			if (teamId != 0) return Filter(cars.Where(a => a.TeamInformation.TeamId == teamId).ToList(), manufacturerId, 0);
			return cars;
		}
	}
}
