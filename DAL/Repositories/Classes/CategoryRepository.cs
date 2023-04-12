using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Classes
{
    public class CategoryRepository : GenericRepository<CategoryEntity, int>,
        ICategoryRepository
    {
        private readonly AppEFContext _context;

        public CategoryRepository(AppEFContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<CategoryEntity> Categories => GetAll();
    }
}
