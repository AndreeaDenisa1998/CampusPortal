using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelers.Business.Travelers.Models.Notifications
{
    public class CreateNotificationModel
    {
	    public Guid IdUser { get; set; }
	    public Guid PostId { get; set; }
        public string Content { get; set; }

       
    }
}
