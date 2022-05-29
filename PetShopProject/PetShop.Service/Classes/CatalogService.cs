using PetShop.Data.Models;
using PetShop.Data.Repositories.Interfaces;
using PetShop.Service.Interfaces;

namespace PetShop.Service.Classes
{
    public class CatalogService : ICatalogService
    {
        private readonly IAnimalRepository MyAnimalRepository;
        public CatalogService(IAnimalRepository animalRepository)
        {
            MyAnimalRepository = animalRepository;
        }

        public async Task<Animal?> GetAnimal(int id)
        {
            return await MyAnimalRepository.Get(id);
        }

        public async Task<Animal?> GetAnimalByName(string name)
        {
            if (MyAnimalRepository.GetByName(name) == null) return null;
            return await MyAnimalRepository.GetByName(name);
        }

        public IQueryable<Animal> GetAllAnimals()
        {
            return MyAnimalRepository.GetAll();
        }
        public IQueryable<Category> GetAllCatagories() => MyAnimalRepository.GetAllCatagories();




    }
}