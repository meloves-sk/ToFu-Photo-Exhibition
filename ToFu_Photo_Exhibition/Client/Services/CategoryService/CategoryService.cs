namespace ToFu_Photo_Exhibition.Client.Services.CategoryService
{
	public class CategoryService : ICategoryService
	{
		private readonly HttpClient _http;
		public CategoryService(HttpClient http)
		{
			_http = http;
		}
		public List<CategoryResponseDto> Categories { get; } = new List<CategoryResponseDto>();
		public bool IsInitializeOrSearch { get; set; } = true;

		public async Task GetCategories()
		{
			Categories.Clear();
			IsInitializeOrSearch = true;
			var result = await _http.GetFromJsonAsync<ServiceResponse<IEnumerable<CategoryResponseDto>>>($"api/category");
			if (result != null && result.Data != null)
			{
				Categories.AddRange(result.Data);
				IsInitializeOrSearch = false;
			}
		}
	}
}
