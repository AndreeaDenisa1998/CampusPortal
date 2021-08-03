using Microsoft.EntityFrameworkCore;
using Travelers.Entities;

namespace Campus.Persistence.Mappings
{
	internal abstract class NotificationMapping
        {
            internal static void Map(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Notification>(entity =>
                {
                    entity.Property(c => c.Id)
                        .HasColumnName("Id")
                        .IsRequired();
                    entity.Property(c => c.PostId)
	                    .HasColumnName("IdPosts")
	                    .IsRequired();
                    entity.Property(c => c.Content)
                        .HasColumnName("Content")
                        .IsRequired();
                });
            }
        }
    }