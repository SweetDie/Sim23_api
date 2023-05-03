using BLL.Constants;
using BLL.Services.Interfaces;
using BLL.ViewModels.Category;
using DAL;
using DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Sim23
{
    public static class SeederDB
    {
        public static async void SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();
                var categoryService = scope.ServiceProvider.GetService<ICategoryService>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<RoleEntity>>();

                if (!context.Roles.Any())
                {
                    RoleEntity admin = new RoleEntity
                    {
                        Name = Roles.Admin,
                    };
                    RoleEntity user = new RoleEntity
                    {
                        Name = Roles.User,
                    };
                    var result = roleManager.CreateAsync(admin).Result;
                    result = roleManager.CreateAsync(user).Result;
                }

                if (!context.Users.Any())
                {
                    UserEntity user = new UserEntity
                    {
                        FirstName = "Марко",
                        LastName = "Муха",
                        Email = "muxa@gmail.com",
                        UserName = "muxa@gmail.com",
                    };
                    var result = userManager.CreateAsync(user, "123456")
                        .Result;
                    if (result.Succeeded)
                    {
                        result = userManager
                            .AddToRoleAsync(user, Roles.Admin)
                            .Result;
                    }
                }

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
