using System;

namespace Travelers.Business.Travelers.Models.Notifications
{
    public class NotificationModel
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; }

    }
}
