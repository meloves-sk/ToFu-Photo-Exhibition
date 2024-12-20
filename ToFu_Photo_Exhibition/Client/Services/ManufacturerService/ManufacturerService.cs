
namespace ToFu_Photo_Exhibition.Client.Services.ManufacturerService
{
	public class ManufacturerService : IManufacturerService
	{
		private readonly HttpClient _http;
		public ManufacturerService(HttpClient http)
		{
			_http = http;
		}
		public List<ManufacturerResponseDto> Manufacturers { get; } = new List<ManufacturerResponseDto>();
		public bool IsInitializeOrSearch { get; set; } = true;

		public async Task GetFilterManufacturers(int categoryId)
		{
			Manufacturers.Clear();
			IsInitializeOrSearch = true;
			var result = await _http.GetFromJsonAsync<ServiceResponse<IEnumerable<ManufacturerResponseDto>>>($"api/manufacturer/category/{categoryId}");
			if (result != null && result.Data != null)
			{
				Manufacturers.Add(new ManufacturerResponseDto(0, "ALL"));
				Manufacturers.AddRange(result.Data);
				IsInitializeOrSearch = false;
			}
		}
	}
}
