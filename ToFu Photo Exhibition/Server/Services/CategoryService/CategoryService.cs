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
			var dbCategories = await _db.Categories.ToListAsync();
			IEnumerable<CategoryResponseDto> categories = dbCategories.Select(a =>
				 new CategoryResponseDto(
					 a.Id,
					 a.Name));
			return new ServiceResponse<IEnumerable<CategoryResponseDto>>(categories, true, "正常に取得されました");
		}
	}
}
