using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelers.Business.Travelers.Models.Reviews;

namespace Travelers.Business.Travelers.Services.ReviewS
{
    public interface IReviewService
    {
        Task<ReviewModel> GetById(Guid id);
        Task<ReviewModel> Create(CreateReviewModel model);

        Task Delete(Guid reviewId);

        Task Update(Guid reviewId, CreateReviewModel model);
    }
}
