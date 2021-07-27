using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelers.Business.Travelers.Models.Posts
{
	public class PostModel
	{
		public Guid Id { get; set; }
		public Guid IdUser { get; set; }
		public string Content { get; set; }
		public int NumberOfLikes { get; set; }
		public DateTime Date { get; set; }
		public string Type { get; set; }

	}
}
