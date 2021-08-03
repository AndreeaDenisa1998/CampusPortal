using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelers.Entities
{
	public class Notification : Entity
	{
		public string Content { get; set; }
		public DateTime? Date { get; set; }
		public Guid PostId { get; set; }
		public Guid IdUser { get; set; }
		public User User { get; set; }
		public Post Post { get; set; }


	}
}
