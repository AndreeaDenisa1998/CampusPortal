using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travelers.Business.Travelers.Models.Posts;
using Travelers.Business.Travelers.Services.PostS;
using Travelers.entities;

namespace Travelers.api.Controllers
{
	[Route("api/v1/posts")]
	[ApiController]
	public class PostController : ControllerBase
	{
		private readonly IPostsService postService;
		public PostController(IPostsService postService)
		{
			this.postService = postService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{

			var posts = postService.GetAll();

			return Ok(posts);
		}
		// GET api/<PostsController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get([FromRoute] Guid id)
		{
			var result = await postService.GetPostById(id);
			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest();
		}

		// POST api/<PostsController>
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreatePostModel model)
		{
			try
			{
				var result = await postService.Create(model);
				return Created(result.Id.ToString(), null);
			}
			catch(Exception exception)
			{
				throw exception;
			}
		}

		// PUT api/<PostsController>/5
		[HttpPut]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CreatePostModel model)
		{
			await postService.Update(id, model);
			return NoContent();
		}

		// DELETE api/<PostsController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await postService.Delete(id);
			return NoContent();
		}

		[HttpGet("{postId}/comments")]
		public async Task<IActionResult> GetComments([FromRoute] Guid postId)
		{
			return Ok(await postService.GetComments(postId));
			
		}
		[HttpGet("{postId}/reviews")]
		public async Task<IActionResult> GetReviews([FromRoute] Guid postId)
		{
			return Ok(await postService.GetReviews(postId));

		}
	}
}
