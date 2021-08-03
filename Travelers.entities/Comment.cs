using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelers.Entities
{
	public sealed class Comment : Entity
	{

		public string Content { get; set; }

		public int NumberOfLikes { get; set; }

		public DateTime? Date { get; set; }

		public Guid PostId { get; set; }

		public Guid IdUser { get; set; }

		public Post Posts { get; set; }

		public User Users { get; set; }

	}
}
