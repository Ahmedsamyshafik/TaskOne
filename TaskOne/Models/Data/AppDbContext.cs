using Microsoft.EntityFrameworkCore;
using TaskOne.Models.Seeder;

namespace TaskOne.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Department> departments { get; set; }
        public DbSet<employee> employes { get; set; }
        public DbSet<User> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Handle
            modelBuilder.Entity<Department>()
      .HasMany(d => d.Employees)
      .WithOne(e => e.Department)
      .OnDelete(DeleteBehavior.Cascade);

            // Cascading delete for User -> Employee (CreatedByUser) relationship
            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedEmployees)
                .WithOne(e => e.CreatedByUser)
                .OnDelete(DeleteBehavior.Cascade);

            // Specify No Action for User -> Employee (ModifiedByUser) relationship
            modelBuilder.Entity<User>()
                .HasMany(u => u.ModifiedEmployees)
                .WithOne(e => e.ModifiedByUser)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
            base.OnModelCreating(modelBuilder);

            // Seeding
            modelBuilder.ApplyConfiguration(new DepartmentSeeding());
        }
    }
}
