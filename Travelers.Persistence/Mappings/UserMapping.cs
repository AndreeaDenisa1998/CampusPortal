using Microsoft.EntityFrameworkCore;
using Travelers.entities;

namespace Campus.Persistence.Mappings
{
	internal abstract class UserMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(s => s.Id)
                    .HasColumnName("Id")
                    .IsRequired()
                    .ValueGeneratedNever();
                entity.Property(s => s.Username)
                    .HasColumnName("UserName")
                    .HasMaxLength(200)
                    .IsRequired()
                    .ValueGeneratedNever();
                entity.Property(s => s.Email)
                    .HasColumnName("Email")
                    .HasMaxLength(200)
                    .IsRequired()
                    .ValueGeneratedNever();
                entity.Property(s => s.PasswordHash)
                    .HasColumnName("PasswordHash")
                    .HasMaxLength(25)
                    .IsRequired()
                    .ValueGeneratedNever();
                entity.Property(s => s.Type)
	                .HasColumnName("Type")
	                .IsRequired()
	                .ValueGeneratedNever();

                entity.HasMany(s => s.Posts)
                    .WithOne(p => p.User)
                    .HasForeignKey(s => s.IdUser).OnDelete(DeleteBehavior.Cascade);


                entity.HasMany(u => u.Comments)
	                .WithOne(a => a.Users)
	                .HasForeignKey(u => u.IdUser).OnDelete(DeleteBehavior.Cascade);


                entity.HasMany(u => u.Reviews)
                    .WithOne(r => r.User)
                    .HasForeignKey(u => u.IdUser).OnDelete(DeleteBehavior.Cascade);


                entity.HasMany(u => u.Notifications)
	                .WithOne(t => t.User)
	                .HasForeignKey(i => i.IdUser).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}