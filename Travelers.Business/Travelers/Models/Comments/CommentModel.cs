using System;

namespace Travelers.Business.Travelers.Models.Comments
{
    public class CommentModel
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public int NumberOfLikes { get; set; }
        public DateTime Date { get; set; }
    }
}
