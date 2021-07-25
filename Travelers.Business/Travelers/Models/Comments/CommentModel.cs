using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelers.Business.Travelers.Models.Comments
{
    public class CommentModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int NumberOfLikes { get; set; }
        public DateTime Date { get; set; }
    }
}
