using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travelers.entities;
using Travelers.persistance;

namespace Campus.Persistence
{
	public class ReviewRepository: IReviewRepository
    {
        private readonly TravelersContext context;

        public ReviewRepository(TravelersContext context)
        {
            this.context = context;
        }
        public IEnumerable<Review> GetAll()
        {
	        return context.Review;
        }
        public async Task<Review> GetReviewById(Guid id)
        {
            return await context.Review
                .FirstAsync(s => s.Id == id);
        }
        public void Delete(Review review)
        {
            context.Review.Remove(review);
        }
        public async Task Create(Review review)
        {
            await this.context.Review.AddAsync(review);
        }
        public void Update(Review review)
        {
            this.context.Review.Update(review);
        }
        public async Task SaveChanges()
        {
            await this.context.SaveChangesAsync();
        }
    }
}