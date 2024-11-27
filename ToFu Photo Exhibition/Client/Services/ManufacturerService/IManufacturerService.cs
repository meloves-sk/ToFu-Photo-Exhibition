namespace ToFu_Photo_Exhibition.Client.Services.ManufacturerService
{
	public interface IManufacturerService
	{
		List<ManufacturerResponseDto> Manufacturers { get; }
		Task GetFilterManufacturers(int categoryId);
	}
}
