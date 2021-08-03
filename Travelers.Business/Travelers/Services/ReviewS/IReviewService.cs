using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travelers.Business.Travelers.Models.Reviews;

namespace Travelers.Business.Travelers.Services.ReviewS
{
    public interface IReviewService
    {
	    IEnumerable<ReviewModel> GetAll();
        Task<ReviewModel> GetById(Guid id);
        Task<ReviewModel> Create(CreateReviewModel model);

        Task Delete(Guid reviewId);

        Task Update(Guid reviewId, CreateReviewModel model);
    }
}
