using System;

namespace Travelers.entities
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
