using PetShop.Data.Models;
using PetShop.Data.Repositories.Interfaces;
using PetShop.Service.Interfaces;

namespace PetShop.Service.Classes
{
    public class HomeService : IHomeService
    {
        private readonly IAnimalRepository MyAnimalRepository;
        public HomeService(IAnimalRepository animalRepository)
        {
            MyAnimalRepository = animalRepository;
        }


        public IEnumerable<Animal> Get2TopAnimals()
        {
            return MyAnimalRepository.Get2TopAnimals();
        }
    }
}
