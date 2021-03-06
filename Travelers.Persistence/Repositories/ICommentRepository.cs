using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelers.Entities;

namespace Travelers.Persistence
{
    public interface ICommentRepository
    {
	    IEnumerable<Comment> GetAll();
        Task<Comment> GetCommentById(Guid id);
        Task Create(Comment comment);
        Task SaveChanges();
        void Delete(Comment comment);
        void Update(Comment comment);
    }
}