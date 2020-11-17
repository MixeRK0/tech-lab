using Microsoft.EntityFrameworkCore;
using NewWebApp.Database.Models;

namespace NewWebApp.Database
{
    public class CalculationContext : DbContext
    {
        public CalculationContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
        { }

        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Result>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
