namespace ToFu_Photo_Exhibition.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
	{
		private readonly DB _db;
		public CategoryService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
		{
			List<Category> categories = await _db.Categories.ToListAsync();
			ServiceResponse<List<Category>> response = new ServiceResponse<List<Category>>
			{
				Data = categories,
				Success = true,
				Message = "Success"
			};
			return response;
		}
	}
}
