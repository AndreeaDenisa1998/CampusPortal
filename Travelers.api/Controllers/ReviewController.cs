using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travelers.Business.Travelers.Models.Reviews;
using Travelers.Business.Travelers.Services.ReviewS;

namespace Travelers.api.Controllers
{
	[Route("api/reviews")]

    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await reviewService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReviewModel model)
        {
            var result = await reviewService.Create(model);
            return Created(result.Id.ToString(), null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await reviewService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CreateReviewModel model)
        {
            await reviewService.Update(id, model);
            return NoContent();
        }
    }
}
