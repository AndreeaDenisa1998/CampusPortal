using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travelers.Business.Travelers.Models.Comments;
using Travelers.Business.Travelers.Services.CommentS;

namespace Travelers.api.Controllers
{
	[Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await commentService.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateModelComment model)
        {
            var result = await commentService.Create(model);
            return Created(result.Id.ToString(), null);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await commentService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CreateModelComment model)
        {
            await commentService.Update(id, model);
            return NoContent();
        }
    }
}
