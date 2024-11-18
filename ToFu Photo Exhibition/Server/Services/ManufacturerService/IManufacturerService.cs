namespace ToFu_Photo_Exhibition.Server.Services.ManufacturerService
{
	public interface IManufacturerService
	{
		Task<ServiceResponse<List<Manufacturer>>> GetManufacturersAsync(int categoryId);
		Task SaveManufacturer(Manufacturer manufacturer);
	}
}
