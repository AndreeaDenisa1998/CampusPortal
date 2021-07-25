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
        public Review(Guid idUser,Guid idPosts,string content, int numberOfStars, DateTime date, int numberOfLikes) : base()
        {
	        IdPosts = idPosts;
	        IdUsers = idUser;
            Content = content;
            NumberOfLikes = numberOfLikes;
            Date = date;
            NumberOfStars = numberOfStars;

        }
        //[Required, MaxLength(1000)]
        public string Content { get; private set; }

        //[Required]
        public int NumberOfStars { get; private set; }

        //[Required]
        public DateTime Date { get; private set; }

        //[Required]
        public int NumberOfLikes { get; private set; }
        
        public Guid IdUsers { get; private set; }
        
        public Guid IdPosts { get; private set; }

        public Users Users { get; set; }

        public Posts Posts { get; set; }

    }
}
