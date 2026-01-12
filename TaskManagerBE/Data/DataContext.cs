using Microsoft.EntityFrameworkCore;
using TaskManagerBE.Models;

namespace TaskManagerBE.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            RelationshipBuilder(modelBuilder);
            SeedData(modelBuilder);
        }

        private void RelationshipBuilder(ModelBuilder modelBuilder) { }

        private void SeedData(ModelBuilder modelBuilder) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Models.Task> Tasks => Set<Models.Task>();
        public DbSet<Status> Statuses => Set<Status>();
        public DbSet<Assignment> Assignments => Set<Assignment>();
    }
}
