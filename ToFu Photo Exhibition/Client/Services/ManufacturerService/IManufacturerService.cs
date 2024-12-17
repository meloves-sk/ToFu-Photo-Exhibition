namespace ToFu_Photo_Exhibition.Client.Services.ManufacturerService
{
	public interface IManufacturerService
	{
		List<ManufacturerResponseDto> Manufacturers { get; }
		bool IsSearch { get; set; }
		Task GetFilterManufacturers(int categoryId);
	}
}
