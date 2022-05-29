using PetShop.Data.Models;
using PetShop.Data.Repositories.Interfaces;
using PetShop.Service.Interfaces;

namespace PetShop.Service.Classes
{
    public class AdminService : IAdminService
    {
        private readonly IAnimalRepository MYAnimalRepository;
        public AdminService(IAnimalRepository animalRepository)
        {
            MYAnimalRepository = animalRepository;
        }
        public Animal? Update(Animal animal)
        {
            return MYAnimalRepository.Update(animal);
        }
        public async Task<Animal?> DeleteAnimal(Animal animal)
        {
            return await MYAnimalRepository.Delete(animal.AnimalId);
        }
        public async Task<Animal?> GetAnimal(int id)
        {
            return await MYAnimalRepository.Get(id);
        }

        public async Task<Animal?> GetAnimalByName(string name)
        {
            if (MYAnimalRepository.GetByName(name) == null) return null;
            return await MYAnimalRepository.GetByName(name);
        }

        public IQueryable<Animal> GetAllAnimals()
        {
            return MYAnimalRepository.GetAll();
        }

        public IQueryable<Category> GetAllCatagories() => MYAnimalRepository.GetAllCatagories();

        public async Task<Animal?> CreateAnimal(Animal animal)
        {
            await MYAnimalRepository.CreateAnimal(animal);
            return animal;
        }
    }

}
