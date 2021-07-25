using System;
using System.Threading.Tasks;
using Travelers.entities;

namespace Campus.Persistence
{
	public interface IReviewRepository
    {
        Task<Review> GetReviewById(Guid id);
        Task Create(Review review);
        Task SaveChanges();
        void Delete(Review review);
        void Update(Review review);
    }
}