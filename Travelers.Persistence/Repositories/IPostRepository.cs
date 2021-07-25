﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelers.entities;

namespace Travelers.persistance
{
	public interface IPostRepository
	{
		Task<Post> GetPostById(Guid id);
		Task Create(Post post);
		Task SaveChanges();
		void Delete(Post post);
		void Update(Post post);
	}
}