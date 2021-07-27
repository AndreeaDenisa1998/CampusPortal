using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travelers.Business.Travelers.Models.Posts;
using Travelers.Business.Travelers.Services.PostS;

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
			return Ok(result);
		}

		// POST api/<PostsController>
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreatePostModel model)
		{
			var result = await postService.Create(model);

			return Created(result.Id.ToString(), null);
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

	}
}
