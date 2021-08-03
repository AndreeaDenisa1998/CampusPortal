using Microsoft.EntityFrameworkCore;
using Campus.Persistence.Mappings;
using Travelers.Entities;
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