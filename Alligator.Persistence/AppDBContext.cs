using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Alligator.Domain.Model;

namespace Alligator.Persistence
{
    public class BlogPostsCount
    {
        public string BlogName { get; set; }
        public int PostCount { get; set; }
    }

    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BlogPostsCount> BlogPostCounts { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
        .Entity<BlogPostsCount>();
        }
    }
}  
