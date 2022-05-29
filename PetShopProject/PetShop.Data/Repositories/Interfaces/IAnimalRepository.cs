using PetShop.Data.Models;

namespace PetShop.Data.Repositories.Interfaces
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        Task<Animal?> GetByName(string name);
        IQueryable<Category> GetAllCatagories();
        Task<Animal> CreateAnimal(Animal entity);
        IEnumerable<Animal> Get2TopAnimals();

    }

}
