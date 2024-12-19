namespace ToFu_Photo_Exhibition.Client.Services.CarService
{
	public class CarService : ICarService
	{
		private readonly HttpClient _http;
		public CarService(HttpClient http)
		{
			_http = http;
		}
		public List<CarResponseDto> Cars { get; } = new List<CarResponseDto>();
		public bool IsInitializeOrSearch { get; set; } = true;

		public async Task GetFilterCars(int categoryId, int manufacturerId, int teamId)
		{
			Cars.Clear();
			IsInitializeOrSearch = true;
			var result = await _http.GetFromJsonAsync<ServiceResponse<IEnumerable<CarResponseDto>>>($"api/car/category/{categoryId}/manufacturer/{manufacturerId}/team/{teamId}");
			if (result != null && result.Data != null)
			{
				Cars.Add(new CarResponseDto(0, "ALL", 0, 0, string.Empty, string.Empty, string.Empty));
				Cars.AddRange(result.Data);
				IsInitializeOrSearch = false;
			}
		}
	}
}
