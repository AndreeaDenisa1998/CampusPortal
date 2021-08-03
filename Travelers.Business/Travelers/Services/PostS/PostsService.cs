using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Travelers.Business.Travelers.Models.Comments;
using Travelers.Business.Travelers.Models.Posts;
using Travelers.Business.Travelers.Models.Reviews;
using Travelers.Entities;
using Travelers.persistance;

namespace Travelers.Business.Travelers.Services.PostS
{
	public class PostsService : IPostsService
	{
		private readonly IPostRepository postRepository;
		private readonly IMapper mapper;
		public PostsService(IPostRepository postRepository, IMapper mapper)
		{
			this.postRepository = postRepository;
			this.mapper = mapper;
		}
		public IEnumerable<PostModel> GetAll()
		{
			var post = postRepository.GetAll();

			return mapper.Map<IEnumerable<PostModel>>(post);
		}
		public async Task<PostModel> GetPostById(Guid id)
		{
				var posts = await postRepository.GetPostById(id);
				return mapper.Map<PostModel>(posts);

		}
		public async Task<PostModel> Create(CreatePostModel model)
		{
			var posts = this.mapper.Map<Post>(model); 
			await this.postRepository.Create(posts);

			await this.postRepository.SaveChanges();

			return mapper.Map<PostModel>(posts);
			
			
		}
		public async Task Delete(Guid postId)
		{
			var posts = await postRepository.GetPostById(postId);

			postRepository.Delete(posts);

			await postRepository.SaveChanges();
		}
		public async Task Update(Guid postId, CreatePostModel model)
		{
			var posts = await postRepository.GetPostById(postId);

			mapper.Map(model, posts);

			postRepository.Update(posts);

			await postRepository.SaveChanges();
		}

		public async Task<IEnumerable<CommentModel>> GetComments(Guid postId)
		{
			return mapper.Map<IEnumerable<CommentModel>>(await postRepository.GetComments(postId));
		}

		public async Task<IEnumerable<ReviewModel>> GetReviews(Guid postId)
		{
			return mapper.Map<IEnumerable<ReviewModel>>(await postRepository.GetReviews(postId));
		}
	}
}
