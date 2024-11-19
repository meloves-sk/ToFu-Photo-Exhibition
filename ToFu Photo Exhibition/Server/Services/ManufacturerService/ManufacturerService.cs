using ToFu_Photo_Exhibition.Shared.Dto.Request;

namespace ToFu_Photo_Exhibition.Server.Services.ManufacturerService
{
	public class ManufacturerService : IManufacturerService
	{
		private readonly DB _db;
		public ManufacturerService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<IEnumerable<ManufacturerResponseDto>>> GetManufacturersAsync(int categoryId)
		{
			List<ManufacturerResponseDto> manufacturers = new List<ManufacturerResponseDto>();
			manufacturers.Add(new ManufacturerResponseDto(0, "すべて"));
			await _db.Manufacturers.Include(a => a.TeamInformations).Where(a => a.TeamInformations.Any(b => b.CategoryId == categoryId)).ForEachAsync(a => manufacturers.Add(new ManufacturerResponseDto(a.Id, a.Name)));
			return new ServiceResponse<IEnumerable<ManufacturerResponseDto>>
			{
				Data = manufacturers,
				Success = true,
				Message = "Success"
			};
		}

		public async Task SaveManufacturer(ManufacturerRequestDto manufacturerRequestDto)
		{
			Manufacturer _manufacturer = await _db.Manufacturers.FindAsync(manufacturerRequestDto.Id) ?? new Manufacturer();
			_manufacturer.Name = manufacturerRequestDto.Name;
			if (_manufacturer.Id == 0) _db.Manufacturers.Add(_manufacturer);
			await _db.SaveChangesAsync();
		}
	}
}
