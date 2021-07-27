using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campus.Persistence;
using Microsoft.EntityFrameworkCore;
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
			return await context.Post
				.FirstAsync(s => s.Id == id);
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
		public async Task SaveChanges()
		{
			await this.context.SaveChangesAsync();
		}
	}
}
