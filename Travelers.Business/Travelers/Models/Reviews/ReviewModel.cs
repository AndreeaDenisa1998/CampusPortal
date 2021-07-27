using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelers.Business.Travelers.Models.Reviews
{
    public class ReviewModel
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfStars { get; set; }
        public DateTime Date { get; set; }
    }
}
