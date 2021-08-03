using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Campus.Persistence;
using Travelers.Business.Travelers.Models.Notifications;
using Travelers.Entities;

namespace Travelers.Business.Travelers.Services.NotificationS
{
    public class NotificationService: INotificationService
    {
        private readonly INotificationRepository notificationRepository;
        private readonly IMapper mapper;
        public NotificationService(INotificationRepository notificationRepository, IMapper mapper)
        {
            this.notificationRepository = notificationRepository;
            this.mapper = mapper;
        }
        public IEnumerable<NotificationModel> GetAll()
        {
	        var notifications = notificationRepository.GetAll();

	        return mapper.Map<IEnumerable<NotificationModel>>(notifications);
        }
        public async Task<NotificationModel> GetById(Guid id)
        {
            var notification = await notificationRepository.GetNotificationById(id);
            return mapper.Map<NotificationModel>(notification);
        }
        public async Task<NotificationModel> Create(CreateNotificationModel model)
        {
            var notification = this.mapper.Map<Notification>(model);

            await this.notificationRepository.Create(notification);

            await this.notificationRepository.SaveChanges();

            return mapper.Map<NotificationModel>(notification);
        }
        public async Task Delete(Guid reviewId)
        {
            var notification = await notificationRepository.GetNotificationById(reviewId);

            notificationRepository.Delete(notification);

            await notificationRepository.SaveChanges();
        }
        public async Task Update(Guid reviewId, CreateNotificationModel model)
        {
            var notification = await notificationRepository.GetNotificationById(reviewId);

            mapper.Map(model, notification);

            notificationRepository.Update(notification);

            await notificationRepository.SaveChanges();
        }


    }
}
