using Microsoft.EntityFrameworkCore;
using Travelers.entities;

namespace Campus.Persistence.Mappings
{
    internal abstract class ReviewMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>(entity =>
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
                entity.Property(c => c.NumberOfStars)
                    .HasColumnName("NumberOfStars")
                    .IsRequired();
                entity.Property(c => c.NumberOfLikes)
                    .HasColumnName("numberOfLikes")
                    .IsRequired();
                entity.Property(c => c.Date)
                    .HasColumnName("Date")
                    .IsRequired();
            });
        }
    }
}