﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelers.Business.Travelers.Models.Users
{
	public sealed class UsersModel
    {
        public Guid IdUsers { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }

        public string Type { get; set; }

        public Guid IdTypeUsers { get; set; }


       
    }
}
