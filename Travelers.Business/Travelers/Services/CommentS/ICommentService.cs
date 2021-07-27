using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelers.Business.Travelers.Models.Comments;

namespace Travelers.Business.Travelers.Services.CommentS
{
    public interface ICommentService
    {
	    IEnumerable<CommentModel> GetAll();
        Task<CommentModel> GetById(Guid id);
        Task<CommentModel> Create(CreateCommentModel model);
        
        Task Delete(Guid commentId);

        Task Update(Guid commentId, CreateCommentModel model);
    }
}
