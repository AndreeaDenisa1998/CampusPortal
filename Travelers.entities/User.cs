using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelers.Entities
{
	public sealed class User : Entity
	{
		public User()
		{
		}
		public string Username { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public string Type { get; set; }
		public ICollection<Post> Posts { get; set; }
		public ICollection<Comment> Comments { get; set; }
		public ICollection<Notification> Notifications { get; set; }
		public ICollection<Review> Reviews { get; set; }


	}
}
