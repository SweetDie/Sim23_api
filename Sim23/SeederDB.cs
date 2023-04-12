using BLL.Services.Interfaces;
using BLL.ViewModels.Category;

namespace Sim23
{
    public static class SeederDB
    {
        public static async void SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var categoryService = scope.ServiceProvider.GetService<ICategoryService>();

                if (!(await categoryService.GetAllAsync()).Any())
                {
                    var category = new CategoryCreateVM
                    {
                        Name = "Гарячі напої",
                        Priority = 2,
                        Description = "Гарячі напої якщо потрібно зігрітися"
                    };
                    await categoryService.CreateCategoryAsync(category);

                    category = new CategoryCreateVM
                    {
                        Name = "Гаряча їжа",
                        Priority = 1,
                        Description = "Дуже смачна гаряча домашня їжа"
                    };
                    await categoryService.CreateCategoryAsync(category);

                    category = new CategoryCreateVM
                    {
                        Name = "Пекарня",
                        Priority = 3,
                        Description = "Смачна випічка. Краще ніж у дома"
                    };
                    await categoryService.CreateCategoryAsync(category);
                }
            }
        }
    }
}
