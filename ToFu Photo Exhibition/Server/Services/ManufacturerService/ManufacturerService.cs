namespace ToFu_Photo_Exhibition.Server.Services.ManufacturerService
{
	public class ManufacturerService : IManufacturerService
	{
		private readonly DB _db;
		public ManufacturerService(DB db)
		{
			_db = db;
		}

		public async Task<ServiceResponse<IEnumerable<ManufacturerResponseDto>>> GetFilterManufacturersAsync(int categoryId)
		{
			IEnumerable<ManufacturerResponseDto> manufacturers = (await _db.Manufacturers.Include(a => a.TeamInformations)
				.Where(a => a.TeamInformations.Any(b => b.CategoryId == categoryId)).ToListAsync())
				.Select(a => new ManufacturerResponseDto(a.Id, a.Name));
			return new ServiceResponse<IEnumerable<ManufacturerResponseDto>>(manufacturers, true, "正常に取得されました");
		}

		public async Task<ServiceResponse<bool>> SaveManufacturer(ManufacturerRequestDto manufacturerRequestDto)
		{
			if (await _db.Manufacturers.Where(a => a.Id != manufacturerRequestDto.Id).AnyAsync(a => a.Name == manufacturerRequestDto.Name))
			{
				return new ServiceResponse<bool>(false, false, "このメーカー情報は既に登録されています");
			}
			Manufacturer _manufacturer = await _db.Manufacturers.FindAsync(manufacturerRequestDto.Id) ?? new Manufacturer();
			_manufacturer.Name = manufacturerRequestDto.Name;
			if (_manufacturer.Id == 0)
			{
				_db.Manufacturers.Add(_manufacturer);
			}
			await _db.SaveChangesAsync();
			return new ServiceResponse<bool>(true, true, "正常に保存されました");
		}
	}
}
