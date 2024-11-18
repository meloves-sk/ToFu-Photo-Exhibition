namespace ToFu_Photo_Exhibition.Server.Services.ManufacturerService
{
	public class ManufacturerService : IManufacturerService
	{
		private readonly DB _db;
		public ManufacturerService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<List<Manufacturer>>> GetManufacturersAsync(int categoryId)
		{
			List<Manufacturer> manufacturers = new List<Manufacturer>();
			manufacturers.Add(new Manufacturer { Id = 0, Name = "すべて" });
			manufacturers.AddRange(await _db.Manufacturers.Include(a => a.TeamInformations).Where(a => a.TeamInformations.Any(b => b.CategoryId == categoryId)).ToListAsync());
			ServiceResponse<List<Manufacturer>> response = new ServiceResponse<List<Manufacturer>>
			{
				Data = manufacturers,
				Success = true,
				Message = "Success"
			};
			return response;
		}

		public async Task SaveManufacturer(Manufacturer manufacturer)
		{
			Manufacturer _manufacturer = await _db.Manufacturers.FindAsync(manufacturer.Id) ?? new Manufacturer();
			_manufacturer.Name = manufacturer.Name;
			if (_manufacturer.Id == 0) _db.Manufacturers.Add(_manufacturer);
			_db.SaveChanges();
		}
	}
}
