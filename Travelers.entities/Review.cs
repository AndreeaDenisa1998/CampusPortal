using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelers.entities
{
    public sealed class Review : Entity
    {
	    public Review()
	    {
	    }

	    public string Content { get; set; }
        
        public int NumberOfStars { get; set; }
        
        public DateTime Date { get; set; }
        
        public int NumberOfLikes { get; set; }
        
        public Guid IdUser { get; set; }
        
        public Guid PostId { get; set; }

        public User User { get; set; }

        public Post Post { get; set; }

    }
}
