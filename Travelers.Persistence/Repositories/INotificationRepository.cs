using System;
using System.Threading.Tasks;
using Travelers.entities;

namespace Campus.Persistence
{
	public interface INotificationRepository
    {
        Task<Notification> GetNotificationById(Guid id);
        Task Create(Notification notification);
        Task SaveChanges();
        void Delete(Notification notification);
        void Update(Notification notification);
    }
}