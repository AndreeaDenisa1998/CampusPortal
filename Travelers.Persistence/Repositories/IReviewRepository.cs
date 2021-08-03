using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travelers.Entities;

namespace Campus.Persistence
{
	public interface IReviewRepository
    {
	    IEnumerable<Review> GetAll();
        Task<Review> GetReviewById(Guid id);
        Task Create(Review review);
        Task SaveChanges();
        void Delete(Review review);
        void Update(Review review);
    }
}