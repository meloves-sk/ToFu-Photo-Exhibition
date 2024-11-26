using ToFu_Photo_Exhibition.Shared.Models;

namespace ToFu_Photo_Exhibition.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<IEnumerable<CategoryResponseDto>>> GetCategoriesAsync();
    }
}
