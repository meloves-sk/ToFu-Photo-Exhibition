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
			var getManufacturers = await _db.Manufacturers.Include(a => a.TeamInformations).ToListAsync();
			manufacturers.AddRange(getManufacturers.Where(a => a.TeamInformations.Any(b => b.CategoryId == categoryId)));
			ServiceResponse<List<Manufacturer>> response = new ServiceResponse<List<Manufacturer>>
			{
				Data = manufacturers,
				Success = true,
				Message = "Success"
			};
			return response;
		}
	}
}
