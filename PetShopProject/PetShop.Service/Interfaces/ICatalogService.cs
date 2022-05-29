using PetShop.Data.Models;


namespace PetShop.Service.Interfaces
{
    public interface ICatalogService
    {

        Task<Animal?> GetAnimal(int id);

        Task<Animal?> GetAnimalByName(string name);

        IQueryable<Animal> GetAllAnimals();

        IQueryable<Category> GetAllCatagories();



    }
}
