using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelers.entities;

namespace Travelers.persistance
{

	public interface IUsersRepository
	{
		IEnumerable<User> GetAll();

		Task<User> GetUserById(Guid idUsers);

		Task Create(User user);

		void Update(User users);

		void Delete(User user);

		Task SaveChanges();
	}
}