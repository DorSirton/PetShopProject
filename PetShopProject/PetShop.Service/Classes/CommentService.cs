using PetShop.Data.Models;
using PetShop.Data.Repositories.Interfaces;
using PetShop.Service.Interfaces;

namespace PetShop.Service.Classes
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository MyCommentRepository;
        public CommentService(ICommentRepository commentService)
        {
            MyCommentRepository = commentService;
        }
        public async Task<int> AddComment(Comment c)
        {
            return await MyCommentRepository.AddComment(c);
        }
        public IQueryable<Comment> GetAllComments(int id) => MyCommentRepository.GetAllComments(id);
        public async Task<Comment> RemoveComment(int id)
        {
            return await MyCommentRepository.Delete(id);
        }
    }
}
