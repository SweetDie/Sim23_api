using BLL.ViewModels.Category;
using DAL.Entities;

namespace BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetAllAsync();
        Task<CategoryEntity> CreateCategoryAsync(CategoryCreateVM model);
    }
}
