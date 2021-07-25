using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelers.entities
{
    public sealed class TypesUsers : Entity
    {

        public TypesUsers(Guid idUsers, string type) : base()
        {
            IdUsers = idUsers;
            Type = type;
            //0-super admin, 1-admin owner, 2-user

        }

        //[Required]
        public string Type { get; private set; }

        
        public Guid IdUsers { get; private set; }
        public Users Users { get; set; }

    }
}
