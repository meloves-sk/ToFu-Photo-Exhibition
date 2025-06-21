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
			var filterPhotos = Filter(await _db.Photos.Include(a => a.Round).ThenInclude(a => a.Category)
				.Include(a => a.Car).ThenInclude(a => a.TeamInformation).ThenInclude(a => a.Team)
				.Include(a => a.Car).ThenInclude(a => a.TeamInformation).ThenInclude(a => a.Manufacturer).ToListAsync(),
				categoryId, roundId, manufacturerId, teamId, carId);
			IEnumerable<PhotoResponseDto> photos = filterPhotos.OrderBy(a => a.Round.CategoryId)
				.ThenBy(a => a.Car.CarNo)
				.ThenBy(a => a.Round.Name)
				.Select(a =>
			new PhotoResponseDto(
					a.Id,
					a.FilePath,
					a.Description,
					a.RoundId,
					a.CarId,
					a.Round.Name,
					a.Round.Category.Name,
					a.Car.Name, a.Car.CarNo,
					a.Car.TeamInformation.Team.Name,
					a.Car.TeamInformation.Manufacturer.Name));
			return new ServiceResponse<IEnumerable<PhotoResponseDto>>(photos, true, "正常に取得されました");
		}

		public async Task<ServiceResponse<bool>> SavePhoto(PhotoRequestDto photoRequestDto)
		{
			var photo = await _db.Photos.FindAsync(photoRequestDto.Id) ?? new Photo();
			photo.Description = photoRequestDto.Description;
			photo.RoundId = photoRequestDto.RoundId;
			photo.CarId = photoRequestDto.CarId;
			if (photo.Id == 0)
			{
				string filename = $"image{DateTime.Now.ToString("yyyyMMddHHmmss")}{Path.GetRandomFileName()}.jpg";
				photo.FilePath = $"images/{filename}";
				await File.WriteAllBytesAsync($"wwwroot/images/{filename}", photoRequestDto.PhotoData!);
				_db.Photos.Add(photo);
			}
			await _db.SaveChangesAsync();
			return new ServiceResponse<bool>(true, true, "正常に保存されました");
		}
		public async Task<ServiceResponse<bool>> DeletePhoto(int photoId)
		{
			var photo = await _db.Photos.SingleAsync(a => a.Id == photoId);
			File.Delete($"wwwroot/{photo.FilePath}");
			_db.Photos.Remove(photo);
			await _db.SaveChangesAsync();
			return new ServiceResponse<bool>(true, true, "正常に削除されました");
		}

		private IEnumerable<Photo> Filter(IEnumerable<Photo> photos, int categoryId, int roundId, int manufacturerId, int teamId, int carId)
		{
			if (categoryId != 0)
			{
				return Filter(photos.Where(a => a.Round.CategoryId == categoryId), 0, roundId, manufacturerId, teamId, carId);
			}
			if (roundId != 0)
			{
				return Filter(photos.Where(a => a.RoundId == roundId), categoryId, 0, manufacturerId, teamId, carId);
			}
			if (manufacturerId != 0)
			{
				return Filter(photos.Where(a => a.Car.TeamInformation.ManufacturerId == manufacturerId), categoryId, roundId, 0, teamId, carId);
			}
			if (teamId != 0)
			{
				return Filter(photos.Where(a => a.Car.TeamInformation.TeamId == teamId), categoryId, roundId, manufacturerId, 0, carId);
			}
			if (carId != 0)
			{
				return Filter(photos.Where(a => a.CarId == carId), categoryId, roundId, manufacturerId, teamId, 0);
			}
			return photos;
		}
	}
}
