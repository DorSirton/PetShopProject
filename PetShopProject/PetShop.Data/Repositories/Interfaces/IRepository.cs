namespace PetShop.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> Get(int id);
        IQueryable<T> GetAll();
        T? Update(T entity);
        Task<T?> Delete(int id);
    }

}
