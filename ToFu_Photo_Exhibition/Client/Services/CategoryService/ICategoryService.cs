namespace ToFu_Photo_Exhibition.Client.Services.CategoryService
{
	public interface ICategoryService
	{
		List<CategoryResponseDto> Categories { get; }
		bool IsInitializeOrSearch { get; set; }
		Task GetCategories();
	}
}
