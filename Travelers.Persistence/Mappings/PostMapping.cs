using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travelers.entities;

namespace Travelers.persistance.Mappings
{
	internal abstract class PostMapping
	{
		internal static void Map(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Post>(entity =>
			{
				entity.Property(c => c.Id)
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
				entity.Property(c => c.Type)
					.HasColumnName("Type")
					.IsRequired();

				entity.HasMany(u => u.Comments)
					.WithOne(a => a.Posts)
					.HasForeignKey(u => u.PostId).OnDelete(DeleteBehavior.NoAction);

				entity.HasMany(u => u.Reviews)
					.WithOne(r => r.Post)
					.HasForeignKey(u => u.PostId).OnDelete(DeleteBehavior.NoAction);

				entity.HasOne(u => u.Notification)
					.WithOne(n => n.Post)
					.HasForeignKey<Notification>(d => d.PostId).OnDelete(DeleteBehavior.NoAction);


			});
		}
	}
}
