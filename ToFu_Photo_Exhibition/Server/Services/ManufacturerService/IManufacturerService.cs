namespace ToFu_Photo_Exhibition.Server.Services.ManufacturerService
{
	public interface IManufacturerService
	{
		Task<ServiceResponse<IEnumerable<ManufacturerResponseDto>>> GetFilterManufacturersAsync(int categoryId);
		Task<ServiceResponse<bool>> SaveManufacturer(ManufacturerRequestDto manufacturerRequestDto);
		Task<ServiceResponse<bool>> DeleteManufacturer(int manufacturerId);
	}
}
