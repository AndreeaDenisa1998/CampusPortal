using System;

namespace Travelers.Business.Travelers.Models.Comments
{
    public class CreateCommentModel
    {
	    public Guid IdUser { get; set; }
	    public Guid PostId { get; set; }
        public string Content { get; set; }
        public int NumberOfLikes { get; set; }
        public DateTime Date { get; set; }


    }
}
