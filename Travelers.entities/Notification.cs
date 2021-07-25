using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelers.entities
{
    public class Notification : Entity
    {
        public Notification(string content,Guid idUsers , DateTime date) : base()
        {
            Content = content;
            IdUsers = idUsers;
            Date = date;

        }
        //[Required, MaxLength(1000)]
        public string Content { get; private set; }

        //[Required]
        public DateTime Date { get; private set; }
        
        public Guid IdUsers { get; private set; }
        
        public Guid IdPosts { get; private set; }


        public Users Users { get; set; }
        public Posts Posts { get; set; }

    }
}
