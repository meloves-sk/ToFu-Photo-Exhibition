using ToFu_Photo_Exhibition.Shared.Models;
using ToFu_Photo_Exhibition.Shared;

namespace ToFu_Photo_Exhibition.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<Category>>> GetCategoriesAsync();
    }
}
