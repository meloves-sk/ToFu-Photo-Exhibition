namespace ToFu_Photo_Exhibition.Client.Services.PhotoService
{
	public class PhotoService : IPhotoService
	{
		private readonly HttpClient _http;
		public PhotoService(HttpClient http)
		{
			_http = http;
		}
		public List<PhotoResponseDto> Photos { get; } = new List<PhotoResponseDto>();
		public bool IsInitializeOrSearch { get; set; } = true;

		public async Task GetFilterPhotos(int categoryId, int roundId, int manufacturerId, int teamId, int carId)
		{
			Photos.Clear();
			IsInitializeOrSearch = true;
			var result = await _http.GetFromJsonAsync<ServiceResponse<IEnumerable<PhotoResponseDto>>>($"api/photo/category/{categoryId}/round/{roundId}/manufacturer/{manufacturerId}/team/{teamId}/car/{carId}");
			if (result != null && result.Data != null)
			{
				Photos.AddRange(result.Data);
				IsInitializeOrSearch = false;
			}
		}
	}
}
