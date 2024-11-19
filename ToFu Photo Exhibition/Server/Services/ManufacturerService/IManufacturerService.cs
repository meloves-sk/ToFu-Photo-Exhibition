using ToFu_Photo_Exhibition.Shared.Dto.Request;

namespace ToFu_Photo_Exhibition.Server.Services.ManufacturerService
{
	public interface IManufacturerService
	{
		Task<ServiceResponse<IEnumerable<ManufacturerResponseDto>>> GetManufacturersAsync(int categoryId);
		Task SaveManufacturer(ManufacturerRequestDto manufacturerRequestDto);
	}
}
