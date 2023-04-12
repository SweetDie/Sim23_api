using AutoMapper;
using BLL.Services.Interfaces;
using BLL.ViewModels.Category;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Classes
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryVM>> GetAllAsync()
        {
            var categories = await _categoryRepository.Categories.ToListAsync();
            var categoriesVM = _mapper.Map<List<CategoryVM>>(categories);
            return categoriesVM;
        }
    }
}
