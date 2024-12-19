namespace ToFu_Photo_Exhibition.Client.Services.ManufacturerService
{
	public interface IManufacturerService
	{
		List<ManufacturerResponseDto> Manufacturers { get; }
		bool IsInitializeOrSearch { get; set; }
		Task GetFilterManufacturers(int categoryId);
	}
}
