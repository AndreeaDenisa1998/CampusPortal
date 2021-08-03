using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelers.Entities
{
	public sealed class Post : Entity
	{
		public Post()
		{

		}

		public string Content { get; set; }

		public DateTime? Date { get; set; }

		public int NumberOfLikes { get; set; }

		public string Type { get; set; }

		public Guid IdUser { get; set; }

		public User User { get; set; }

		public Notification Notification { get; set; }

		public ICollection<Comment> Comments { get; set; }

		public ICollection<Review> Reviews { get; set; }


	}
}
