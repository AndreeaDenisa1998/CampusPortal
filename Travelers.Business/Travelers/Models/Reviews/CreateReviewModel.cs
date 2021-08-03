using System;

namespace Travelers.Business.Travelers.Models.Reviews
{
    public class CreateReviewModel
    {
	    public Guid IdUser { get; set; }
	    public Guid PostId { get; set; }
		public string Content { get; set; }
	    public int NumberOfLikes { get; set; }
	    public int NumberOfStars { get; set; }
	    public DateTime Date { get; set; }

        

    }
}
