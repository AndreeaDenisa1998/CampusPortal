using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Campus.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Travelers.entities;

namespace Travelers.persistance
{
	public class PostRepository : IPostRepository
	{
		private readonly TravelersContext context;

		public PostRepository(TravelersContext context)
		{
			this.context = context;
		}
		public IEnumerable<Post> GetAll()
		{
			return context.Post;
		}
		public async Task<Post> GetPostById(Guid id)
		{
			var result = await context.Post.FirstAsync(s => s.Id == id);
			//		var res = await context.Post.FindAsync(id);
			return result;
		}
		public void Delete(Post post)
		{
			context.Post.Remove(post);
		}
		public async Task Create(Post post)
		{
			await this.context.Post.AddAsync(post);
		}
		public void Update(Post post)
		{
			this.context.Post.Update(post);
		}

		public async Task<IEnumerable<Comment>> GetComments(Guid postId)
		{
			return await context.Comment.Where(x => x.PostId == postId).ToArrayAsync();
		}

		public async Task<IEnumerable<Review>> GetReviews(Guid postId)
		{
			return await context.Review.Where(x => x.PostId == postId).ToArrayAsync();
		}

		public async Task SaveChanges()
		{
			await this.context.SaveChangesAsync();
		}
	}
}
