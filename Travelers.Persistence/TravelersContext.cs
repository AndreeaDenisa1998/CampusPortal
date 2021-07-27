/*using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Travelers.entities;

namespace Campus.Persistence
{
	public sealed class TravelersContext : DbContext
	{
        public TravelersContext(DbContextOptions<TravelersContext> options) : base(options)
        {
            Database.Migrate();

        }

        public TravelersContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=DESKTOP-BS3Q1EC\SQLEXPRESS;Initial Catalog=Travelers;Integrated Security=True";


            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
	        modelBuilder.Entity<Users>()
		        .HasOne<TypesUsers>(user => user.TypesUsers)
		        .WithOne()
		        .OnDelete(DeleteBehavior.Cascade);

	        modelBuilder.Entity<TypesUsers>()
		        .Property(s => s.UserId)
		        .IsRequired()
		        .ValueGeneratedNever();

	        modelBuilder.Entity<Posts>()
		        .HasOne<TypesPosts>(user => user.TypesPosts)
		        .WithOne()
		        .OnDelete(DeleteBehavior.Cascade);
	        
	        
	        modelBuilder.Entity<TypesPosts>()
		        .Property(s => s.IdPosts)
		        .IsRequired()
		        .ValueGeneratedNever();
	        

	        modelBuilder.Entity<Posts>()
		        .HasMany<Comments>(user => user.Comments)
		        .WithOne()
		        .OnDelete(DeleteBehavior.Cascade);
	        modelBuilder.Entity<Comments>()
		        .Property(s => s.Id)
		        .IsRequired()
		        .ValueGeneratedNever();


	        modelBuilder.Entity<Posts>()
		        .HasMany<Review>(user => user.Reviews)
		        .WithOne()
		        .OnDelete(DeleteBehavior.Cascade);
	        modelBuilder.Entity<Review>()
		        .Property(s => s.Id)
		        .IsRequired()
		        .ValueGeneratedNever();




	        modelBuilder.Entity<Notification>()
		        .HasOne<Posts>(user => user.Posts)
		        .WithOne()
		        .OnDelete(DeleteBehavior.Cascade);
			
	        
	        modelBuilder.Entity<Posts>()
		        .Property(s => s.Id)
		        .IsRequired()
		        .ValueGeneratedNever();
        }
    

        public DbSet<Users> Users { get; set; }

        public DbSet<TypesUsers> TypesUsers { get; set; }

        public DbSet<Posts> Posts { get; set; }

        public DbSet<TypesPosts> TypesPosts { get; set; }
        public DbSet<Comments> Comments { get; set; }

        public DbSet<Notification> Notification { get; set; }
        public DbSet<Review> Review { get; set; }
        

    }
}*/

using Travelers.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Campus.Persistence.Mappings;
using Travelers.persistance.Mappings;

namespace Travelers.persistance
{
    public class TravelersContext : DbContext
    {
        public TravelersContext()
        {

        }
        public TravelersContext(DbContextOptions<TravelersContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Review> Review { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=DESKTOP-BS3Q1EC\SQLEXPRESS;Initial Catalog=Base1;Integrated Security=True";

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CommentMapping.Map(modelBuilder);
            NotificationMapping.Map(modelBuilder);
            PostMapping.Map(modelBuilder);
            ReviewMapping.Map(modelBuilder);
            UserMapping.Map(modelBuilder);

        }



    }
}