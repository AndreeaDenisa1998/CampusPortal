using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelers.Entities;

namespace Travelers.persistance
{
	public interface IPostRepository
	{
		IEnumerable<Post> GetAll();
		Task<Post> GetPostById(Guid id);
		Task Create(Post post);
		Task SaveChanges();
		void Delete(Post post);
		void Update(Post post);
		Task<IEnumerable<Comment>> GetComments(Guid postId);

		Task<IEnumerable<Review>> GetReviews(Guid postId);
	}
}
