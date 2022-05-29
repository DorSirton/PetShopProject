using PetShop.Data.Models;

namespace PetShop.Data.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category?> AddCategory(int id, string? name);
    }
}
