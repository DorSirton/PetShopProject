using PetShop.Data.Models;

namespace PetShop.Data.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment?> Update(Comment entity);
        Task<Comment> Delete(int id);
        Task<Comment?> Get(int id);
        Task<int> AddComment(Comment c);
        IQueryable<Comment> GetAllComments(int id);


    }
}
