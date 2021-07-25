using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campus.Persistence;
using Microsoft.EntityFrameworkCore;
using Travelers.entities;

namespace Travelers.persistance
{
	public class UsersRepository : IUsersRepository
    {
        private readonly TravelersContext context;

		public UsersRepository(TravelersContext context)
		{
			this.context = context;
		}

		public async Task Create(User user)
        {
            await this.context.User.AddAsync(user);
        }

        public void Delete(User user)
        {
            context.User.Remove(user);
        }

        public IEnumerable<User> GetAll()
        {
            return context.User;
        }

        public async Task<User> GetUserById(Guid idUsers)
        {
            return await context.User
                .FirstAsync(u => u.Id == idUsers);
        }

        public async Task SaveChanges()
        {
            await this.context.SaveChangesAsync();
        }

        public void Update(User user)
        {
            this.context.User.Update(user);
        }
    }
}
