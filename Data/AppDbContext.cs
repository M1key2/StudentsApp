using Microsoft.EntityFrameworkCore;
using StudentsApp.DTOs;
using StudentsApp.Models;

namespace StudentsApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Student>? Students { get; set; }
        public DbSet<Address>? Addresses { get; set; }
        public DbSet<Phone>? Phones { get; set; }
        public DbSet<Email>? Emails { get; set; } 
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is Student || e.Entity is Phone || e.Entity is Email || e.Entity is Address);

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                    entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
