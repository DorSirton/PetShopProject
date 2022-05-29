using PetShop.Data.Models;

namespace PetShop.Service.Interfaces
{
    public interface IHomeService
    {
        IEnumerable<Animal> Get2TopAnimals();

    }
}
