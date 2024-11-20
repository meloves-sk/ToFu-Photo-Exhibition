namespace ToFu_Photo_Exhibition.Server.Services.CategoryService
{
	public class CategoryService : ICategoryService
	{
		private readonly DB _db;
		public CategoryService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<IEnumerable<CategoryResponseDto>>> GetCategoriesAsync()
		{
			List<CategoryResponseDto> categories = new List<CategoryResponseDto>();
			await _db.Categories.ForEachAsync(a => categories.Add(new CategoryResponseDto(a.Id, a.Name)));
			return new ServiceResponse<IEnumerable<CategoryResponseDto>>(categories, true, "正常に取得されました");
		}
	}
}
