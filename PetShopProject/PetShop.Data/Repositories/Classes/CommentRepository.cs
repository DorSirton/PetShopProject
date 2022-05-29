using Microsoft.EntityFrameworkCore;
using PetShop.Data.Context;
using PetShop.Data.Models;
using PetShop.Data.Repositories.Interfaces;

namespace PetShop.Data.Repositories.Classes
{
    public class CommentRepository : ICommentRepository
    {
        private readonly PetShopDataContext MyDataContext;
        public CommentRepository(PetShopDataContext petShopDataContext)
        {
            MyDataContext = petShopDataContext;
        }


        public async Task<Comment> Delete(int id)
        {
            var deleteObject = await Get(id);
            if (deleteObject == null) return null;
            MyDataContext.Comments.Remove(deleteObject);
            await MyDataContext.SaveChangesAsync();
            return deleteObject;
        }

        public async Task<Comment?> Update(Comment entity)
        {
            await Delete(entity.CommentId);
            await MyDataContext.Comments.AddAsync(entity);
            return entity;
        }
        public async Task<Comment?> Get(int id)
        {
            return await MyDataContext.Comments.FirstOrDefaultAsync(c => c.CommentId == id);
        }
        public async Task<int> AddComment(Comment c)
        {
            await MyDataContext.Comments.AddAsync(c);
            await MyDataContext.SaveChangesAsync();
            return c.CommentId;
        }
        public IQueryable<Comment> GetAllComments(int id) => MyDataContext.Comments.Where(c => c.AnimalId == id);


    }
}
