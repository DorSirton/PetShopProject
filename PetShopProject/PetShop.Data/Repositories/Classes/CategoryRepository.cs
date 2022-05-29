using Microsoft.EntityFrameworkCore;
using PetShop.Data.Context;
using PetShop.Data.Models;
using PetShop.Data.Repositories.Interfaces;

namespace PetShop.Data.Repositories.Classes
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PetShopDataContext MyDataContext;
        public CategoryRepository(PetShopDataContext petShopDataContext)
        {
            MyDataContext = petShopDataContext;
        }
        public async Task<Category?> AddCategory(int id, string? name)
        {
            if (await MyDataContext.Categories.FirstOrDefaultAsync(p => p.CategoryId == id) == null) return null;
            var c = new Category();
            c.CategoryId = id;
            c.Name = name;
            await MyDataContext.Categories.AddAsync(c);
            return c;
        }

        public async Task<Category?> Delete(int id)
        {
            var deleteObject = await Get(id);
            if (deleteObject == null) return null;
            MyDataContext.Categories.Remove(deleteObject);
            await MyDataContext.SaveChangesAsync();
            return deleteObject;
        }

        public async Task<Category?> Get(int id)
        {
            return await MyDataContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public IQueryable<Category> GetAll() => MyDataContext.Categories;


        public Category? Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }


}
