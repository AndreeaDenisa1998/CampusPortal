using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelers.Business.Travelers.Models.Comments;
using Travelers.Business.Travelers.Models.Posts;
using Travelers.Business.Travelers.Models.Reviews;

namespace Travelers.Business.Travelers.Services.PostS
{
	public interface IPostsService
    {
	    IEnumerable<PostModel> GetAll();
        Task<PostModel> GetPostById(Guid id);
        Task<PostModel> Create(CreatePostModel model);

        Task Delete(Guid postId);

        Task Update(Guid postId, CreatePostModel model);

        Task<IEnumerable<CommentModel>> GetComments(Guid postId);

        Task<IEnumerable<ReviewModel>> GetReviews(Guid postId);
    }
}
