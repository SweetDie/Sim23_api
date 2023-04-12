using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace Sim23
{
    public static class SeederDB
    {
        public static async void SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var categoryRepository = scope.ServiceProvider.GetService<ICategoryRepository>();

                if (!categoryRepository.Categories.Any())
                {
                    var category = new Category
                    {
                        Name = "Гарячі напої"
                    };
                    await categoryRepository.CreateAsync(category);

                    category = new Category
                    {
                        Name = "Гаряча їжа"
                    };
                    await categoryRepository.CreateAsync(category);

                    category = new Category
                    {
                        Name = "Пекарня"
                    };
                    await categoryRepository.CreateAsync(category);
                }
            }
        }
    }
}
