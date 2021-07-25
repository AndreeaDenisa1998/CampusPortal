using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelers.entities
{
    public sealed class Posts : Entity
    {
	    public Posts()
	    {
		    
	    }

        public Posts(Guid idUsers,string content, byte[] image, int numberOfLikes, DateTime date) : base()
        {
	        IdUsers = idUsers;
            Content = content;
            Image = image;
            NumberOfLikes = numberOfLikes;
            Date = date;


        }
        [Required, MaxLength(1000)]
        public string Content { get; private set; }

        [Required]
        public DateTime Date { get; private set; }

        [Required]
        public int NumberOfLikes { get; private set; }

        [Required]
        public byte[] Image { get; private set; }
        
        public Guid IdUsers { get; private set; }

        public Notification Notification { get; set; }

        public Users Users { get; private set; }
        
        public TypesPosts TypesPosts { get; private set; }

        public ICollection<Comments> Comments { get; private set; }

        public ICollection<Review> Reviews { get; private set; }


    }
}
