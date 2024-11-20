namespace ToFu_Photo_Exhibition.Server.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<IEnumerable<CategoryResponseDto>>>> GetCategory()
		{
			return Ok(await _categoryService.GetCategoriesAsync());
		}
	}
}
