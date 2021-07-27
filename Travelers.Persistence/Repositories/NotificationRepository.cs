using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travelers.entities;
using Travelers.persistance;

namespace Campus.Persistence
{
	public class NotificationRepository : INotificationRepository
    {
        private readonly TravelersContext context;

        public NotificationRepository(TravelersContext context)
        {
            this.context = context;
        }
        public IEnumerable<Notification> GetAll()
        {
	        return context.Notification;
        }
        public async Task<Notification> GetNotificationById(Guid id)
        {
            return await context.Notification
                .FirstAsync(s => s.Id == id);
        }
        public void Delete(Notification notification)
        {
            context.Notification.Remove(notification);
        }
        public async Task Create(Notification notification)
        {
            await this.context.Notification.AddAsync(notification);
        }
        public void Update(Notification notification)
        {
            this.context.Notification.Update(notification);
        }
        public async Task SaveChanges()
        {
            await this.context.SaveChangesAsync();
        }
    }
}