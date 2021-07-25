using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelers.entities
{
	public sealed class TypesPosts : Entity
	{

		public TypesPosts(Guid idPosts, string type) : base()
		{
			IdPosts = idPosts;
			Type = type;

		}

		//[Required]
		public string Type { get; private set; }
		
		public Guid IdPosts { get; private set; }

		public Posts Posts { get; private set; }
		public Users Users { get; set; }

	}
}
