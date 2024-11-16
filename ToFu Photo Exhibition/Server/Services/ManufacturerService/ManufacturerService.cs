namespace ToFu_Photo_Exhibition.Server.Services.ManufacturerService
{
	public class ManufacturerService : IManufacturerService
	{
		private readonly DB _db;
		public ManufacturerService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<List<Manufacturer>>> GetManufacturersAsync()
		{
			List<Manufacturer> manufacturers = await _db.Manufacturers.ToListAsync();
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
