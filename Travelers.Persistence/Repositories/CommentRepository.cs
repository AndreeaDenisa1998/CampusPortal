
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travelers.Entities;
using Travelers.persistance;
using Travelers.Persistence;

namespace Campus.Persistence
{
    public class CommentRepository : ICommentRepository
    {
        private readonly TravelersContext context;

        public CommentRepository(TravelersContext context)
        {
            this.context = context;
        }

        public IEnumerable<Comment> GetAll()
        {
	        return context.Comment;
        }
        public async Task<Comment> GetCommentById(Guid id)
        {
            return await context.Comment
                .FirstAsync(s => s.Id == id);
        }
        public void Delete(Comment comment)
        {
            context.Comment.Remove(comment);
        }
        public async Task Create(Comment comment)
        {
            await this.context.Comment.AddAsync(comment);
        }
        public void Update(Comment comment)
        {
            this.context.Comment.Update(comment);
        }
        public async Task SaveChanges()
        {
            await this.context.SaveChangesAsync();
        }
    }
}