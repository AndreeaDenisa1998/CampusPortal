using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travelers.Entities;

namespace Travelers.persistance.Mappings
{
	internal abstract class CommentMapping
	{
		internal static void Map(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Comment>(entity =>
			{
				entity.Property(c => c.Id)
					.HasColumnName("Id")
					.IsRequired();
				entity.Property(c => c.PostId)
					.HasColumnName("IdPosts")
					.IsRequired();
				entity.Property(c => c.Date)
					.HasColumnName("DateAndTime")
					.IsRequired(false);
				entity.Property(c => c.NumberOfLikes)
					.HasColumnName("NumberOfLikes")
					.IsRequired();
				entity.Property(c => c.Content)
					.HasColumnName("Content")
					.IsRequired();
			});
		}
	}
}
