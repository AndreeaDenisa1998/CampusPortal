using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelers.entities
{
    public sealed class Comments : Entity
    {
         public Comments(Guid idPosts,Guid idUsers,string content, int numberOfLikes, DateTime date) : base()
         {
             IdPosts = idPosts;
             IdUsers = idUsers;
             Content = content;
             NumberOfLikes = numberOfLikes;
             Date = date;
         }
        
        public string Content { get; private set; }
        
        public int NumberOfLikes { get; private set; }
        
        public DateTime Date { get; private set; }

        public Guid IdPosts { get; private set; }
        
        public Guid IdUsers { get; private set; }
        
        public Posts Posts { get; private set; }
        
        public Users Users { get; set; }

    }
}
