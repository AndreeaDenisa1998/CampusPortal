using System;
using System.Collections.Generic;

namespace Travelers.entities
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
