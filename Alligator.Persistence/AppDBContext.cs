using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Alligator.Domain.Model;

namespace Alligator.Persistence
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
            
        }

        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
