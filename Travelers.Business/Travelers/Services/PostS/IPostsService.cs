using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelers.Business.Travelers.Models.Posts;

namespace Travelers.Business.Travelers.Services.PostS
{
	public interface IPostsService
    {
        Task<PostModel> GetPostById(Guid id);
        Task<PostModel> Create(CreatePostModel model);

        Task Delete(Guid postId);

        Task Update(Guid postId, CreatePostModel model);
    }
}
