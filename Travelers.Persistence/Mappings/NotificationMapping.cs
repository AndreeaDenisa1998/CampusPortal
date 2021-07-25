using Microsoft.EntityFrameworkCore;
using Travelers.entities;

namespace Campus.Persistence.Mappings
{
	internal abstract class NotificationMapping
        {
            internal static void Map(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Notification>(entity =>
                {
                    entity.Property(c => c.Id)
                        .HasColumnName("IdNotification")
                        .IsRequired();

                    entity.Property(c => c.Content)
                        .HasColumnName("Content")
                        .IsRequired();
                });
            }
        }
    }