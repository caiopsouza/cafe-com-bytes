using Microsoft.EntityFrameworkCore;
using Take.Entities;

namespace Take.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Genre> Genre { get; set; } = null!;

        public DbSet<Movie> Movie { get; set; } = null!;

        public DbSet<Rate> Rate { get; set; } = null!;

        public DbSet<User> User { get; set; } = null!;

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
