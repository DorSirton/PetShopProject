using PetShop.Data.Models;

namespace PetShop.Service.Interfaces
{
    public interface ICommentService
    {
        Task<int> AddComment(Comment c);
        IQueryable<Comment> GetAllComments(int id);

        Task<Comment> RemoveComment(int id);

    }
}
