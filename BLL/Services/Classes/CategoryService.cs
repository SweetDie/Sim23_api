using AutoMapper;
using BLL.Helpers;
using BLL.Services.Interfaces;
using BLL.ViewModels.Category;
using DAL.Entities;
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

        public async Task<CategoryEntity> CreateCategoryAsync(CategoryCreateVM model)
        {
            var category = _mapper.Map<CategoryEntity>(model);
            if(model.ImageBase64 != null)
            {
                category.Image = ImageWorker.SaveImage(model.ImageBase64);
            }
            await _categoryRepository.CreateAsync(category);
            return category;
        }

        public async Task<List<CategoryVM>> GetAllAsync()
        {
            var categories = await _categoryRepository.Categories
                .Where(c => c.IsDeleted == false)
                .OrderBy(c => c.Priority)
                .ToListAsync();
            var categoriesVM = _mapper.Map<List<CategoryVM>>(categories);
            return categoriesVM;
        }
    }
}
