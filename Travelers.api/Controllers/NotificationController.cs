using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travelers.Business.Travelers.Models.Comments;
using Travelers.Business.Travelers.Models.Notifications;
using Travelers.Business.Travelers.Services.CommentS;
using Travelers.Business.Travelers.Services.NotificationS;

namespace Travelers.api.Controllers
{
	[Route("api/v1/notifications")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService notificationService;
        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {

	        var notification = notificationService.GetAll();

	        return Ok(notification);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await notificationService.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNotificationModel model)
        {
            var result = await notificationService.Create(model);
            return Created(result.Id.ToString(), null);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await notificationService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CreateNotificationModel model)
        {
            await notificationService.Update(id, model);
            return NoContent();
        }
    }
}
