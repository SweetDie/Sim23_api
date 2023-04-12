using BLL.ViewModels.Category;

namespace BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetAllAsync();
    }
}
