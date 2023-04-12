using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category, int>
    {
        IQueryable<Category> Categories { get; }
    }
}
