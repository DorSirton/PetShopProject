using PetShop.Data.Models;

namespace PetShop.Service.Interfaces
{
    public interface IAdminService : ICatalogService
    {
        Task<Animal?> DeleteAnimal(Animal animal);
        Animal? Update(Animal entity);
        Task<Animal?> CreateAnimal(Animal entity);


    }
}
