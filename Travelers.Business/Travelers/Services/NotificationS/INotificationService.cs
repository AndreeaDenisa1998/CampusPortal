using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travelers.Business.Travelers.Models.Notifications;

namespace Travelers.Business.Travelers.Services.NotificationS
{
    public interface INotificationService
    {
	    IEnumerable<NotificationModel> GetAll();
        Task<NotificationModel> GetById(Guid id);
        Task<NotificationModel> Create(CreateNotificationModel model);

        Task Delete(Guid notificationId);

        Task Update(Guid notificationId, CreateNotificationModel model);
    }
}
