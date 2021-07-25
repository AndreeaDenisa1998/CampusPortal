using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelers.Business.Travelers.Models.Users
{
    public sealed class CreateUsersModel
    {
        public string Username { get; set; }

        public string Email { get;set; }

        public string Type { get; set; }

        public string PasswordHash { get; set; }

    }
}
