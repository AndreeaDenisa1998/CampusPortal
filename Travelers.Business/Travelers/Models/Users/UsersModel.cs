using System;

namespace Travelers.Business.Travelers.Models.Users
{
	public sealed class UsersModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }

        public string Type { get; set; }

        public string PasswordHash { get; set; }

    }
}
