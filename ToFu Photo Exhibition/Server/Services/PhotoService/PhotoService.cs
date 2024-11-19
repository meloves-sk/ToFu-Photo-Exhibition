
namespace ToFu_Photo_Exhibition.Server.Services.PhotoService
{
	public class PhotoService : IPhotoService
	{
		private readonly DB _db;
		public PhotoService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<IEnumerable<PhotoResponseDto>>> GetPhotosAsync(int categoryId, int roundId, int manufacturerId, int teamId, int carId)
		{
			List<PhotoResponseDto> photos = new List<PhotoResponseDto>();
			Filter(await _db.Photos.Include(a => a.Round).ThenInclude(a => a.Category)
				.Include(a => a.Car).ThenInclude(a => a.TeamInformation).ThenInclude(a => a.Team)
				.Include(a => a.Car).ThenInclude(a => a.TeamInformation).ThenInclude(a => a.Manufacturer)
				.Where(a => a.Round.CategoryId == categoryId)
				.ToListAsync(), roundId, manufacturerId, teamId, carId).ForEach(a =>
				{
					photos.Add(new PhotoResponseDto(a.Id, a.FilePath, a.Description, a.RoundId, a.CarId, a.Round.Name, a.Round.Category.Name, a.Car.Name, a.Car.CarNo, a.Car.TeamInformation.Team.Name, a.Car.TeamInformation.Manufacturer.Name));
				});
			return new ServiceResponse<IEnumerable<PhotoResponseDto>>
			{
				Data = photos,
				Success = true,
				Message = "Success"
			};
		}

		private List<Photo> Filter(List<Photo> photos, int roundId, int manufacturerId, int teamId, int carId)
		{
			if (roundId != 0) return Filter(photos.Where(a => a.RoundId == roundId).ToList(), 0, manufacturerId, teamId, carId);
			if (manufacturerId != 0) return Filter(photos.Where(a => a.Car.TeamInformation.ManufacturerId == manufacturerId).ToList(), roundId, 0, teamId, carId);
			if (teamId != 0) return Filter(photos.Where(a => a.Car.TeamInformation.TeamId == teamId).ToList(), roundId, manufacturerId, 0, carId);
			if (carId != 0) return Filter(photos.Where(a => a.CarId == carId).ToList(), roundId, manufacturerId, teamId, 0);
			return photos;
		}
	}
}
