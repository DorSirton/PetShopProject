using Microsoft.EntityFrameworkCore;
using PetShop.Data.Context;
using PetShop.Data.Models;
using PetShop.Data.Repositories.Interfaces;

namespace PetShop.Data.Repositories.Classes
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly PetShopDataContext MyDataContext;
        public AnimalRepository(PetShopDataContext petShopDataContext)
        {
            MyDataContext = petShopDataContext;
        }
        public async Task<Animal?> Delete(int id)
        {
            var deleteObject = await Get(id);
            if (deleteObject == null) return null;
            var animalCommntsCollection = await MyDataContext.Comments.Where(c => c.AnimalId == id).ToListAsync();
            foreach (var item in animalCommntsCollection)
            {
                MyDataContext.Comments.Remove(item);
            }
            MyDataContext.Animals.Remove(deleteObject);
            await MyDataContext.SaveChangesAsync();
            return deleteObject;

        }

        public async Task<Animal?> Get(int id) => await MyDataContext.Animals.FirstOrDefaultAsync(animal => animal.AnimalId == id);

        public async Task<Animal?> GetByName(string name) => await MyDataContext.Animals.FirstOrDefaultAsync(animal => animal.Name == name);

        public IQueryable<Animal> GetAll() => MyDataContext.Animals.Include(a => a.Category).Include(a => a.Comments);

        public Animal? Update(Animal entity)
        {
            MyDataContext.Update(entity);
            MyDataContext.SaveChanges();
            return entity;
        }
        public IQueryable<Category> GetAllCatagories() => MyDataContext.Categories;

        public async Task<Animal> CreateAnimal(Animal entity)
        {
            await MyDataContext.Animals.AddAsync(entity);
            await MyDataContext.SaveChangesAsync();
            return entity;
        }
        public IEnumerable<Animal> Get2TopAnimals()
        {
            var top2 = GetAll().OrderByDescending(x => x.Comments.Count).Take(2);
            return top2;
        }


    }
}
