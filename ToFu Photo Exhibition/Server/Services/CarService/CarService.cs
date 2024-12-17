namespace ToFu_Photo_Exhibition.Server.Services.CarService
{
	public class CarService : ICarService
	{
		private readonly DB _db;
		public CarService(DB db)
		{
			_db = db;
		}

		public async Task<ServiceResponse<IEnumerable<CarResponseDto>>> GetFilterCarsAsync(int categoryId, int manufacturerId, int teamId)
		{
			var filterCars = Filter(await _db.Cars.Include(a => a.TeamInformation).ThenInclude(a => a.Team)
				.Include(a => a.TeamInformation).ThenInclude(a => a.Manufacturer)
				.Include(a => a.TeamInformation).ThenInclude(a => a.Category)
				.ToListAsync(), categoryId, manufacturerId, teamId);
			IEnumerable<CarResponseDto> cars = filterCars.Select(a =>
			new CarResponseDto(
				a.Id,
				a.Name,
				a.CarNo,
				a.TeamInformationId,
				a.TeamInformation.Team.Name,
				a.TeamInformation.Manufacturer.Name,
				a.TeamInformation.Category.Name));
			return new ServiceResponse<IEnumerable<CarResponseDto>>(cars, true, "正常に取得されました");
		}

		public async Task<ServiceResponse<bool>> SaveCar(CarRequestDto carRequestDto)
		{
			if (await _db.Cars.Where(a => a.Id != carRequestDto.Id).AnyAsync(a => a.TeamInformationId == carRequestDto.TeamInformationId && a.CarNo == carRequestDto.CarNo))
			{
				return new ServiceResponse<bool>(false, false, "この車両情報は既に登録されています");
			}
			var car = await _db.Cars.FindAsync(carRequestDto.Id) ?? new Car();
			car.Name = carRequestDto.Name;
			car.CarNo = carRequestDto.CarNo;
			car.TeamInformationId = carRequestDto.TeamInformationId;
			if (car.Id == 0)
			{
				_db.Cars.Add(car);
			}
			await _db.SaveChangesAsync();
			return new ServiceResponse<bool>(true, true, "正常に保存されました");
		}

		public async Task<ServiceResponse<bool>> DeleteCar(int carId)
		{
			var car = await _db.Cars.Include(a => a.Photos).SingleAsync(a => a.Id == carId);
			if (car.Photos.Any())
			{
				return new ServiceResponse<bool>(false, false, "この車両は使用されています");
			}
			_db.Cars.Remove(car);
			await _db.SaveChangesAsync();
			return new ServiceResponse<bool>(true, true, "正常に削除されました");
		}

		private IEnumerable<Car> Filter(IEnumerable<Car> cars, int categoryId, int manufacturerId, int teamId)
		{
			if (categoryId != 0)
			{
				return Filter(cars.Where(a => a.TeamInformation.CategoryId == categoryId), 0, manufacturerId, teamId);
			}
			if (manufacturerId != 0)
			{
				return Filter(cars.Where(a => a.TeamInformation.ManufacturerId == manufacturerId), categoryId, 0, teamId);
			}
			if (teamId != 0)
			{
				return Filter(cars.Where(a => a.TeamInformation.TeamId == teamId), categoryId, manufacturerId, 0);
			}
			return cars;
		}
	}
}
