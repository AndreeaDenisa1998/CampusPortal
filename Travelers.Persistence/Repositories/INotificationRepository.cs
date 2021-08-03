using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travelers.Entities;

namespace Campus.Persistence
{
	public interface INotificationRepository
    {
	    IEnumerable<Notification> GetAll();
        Task<Notification> GetNotificationById(Guid id);
        Task Create(Notification notification);
        Task SaveChanges();
        void Delete(Notification notification);
        void Update(Notification notification);
    }
}