using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Data
{
    public class CollegeDBContext : DbContext
    {
        public CollegeDBContext(DbContextOptions<CollegeDBContext> options) : base(options)
        {
        }

        public DbSet<student> Students { get; set; } // <-- public

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<student>(entity =>
            {
                entity.Property(n => n.Name).IsRequired().HasMaxLength(250);
                entity.Property(n => n.Email).IsRequired();
                entity.Property(n => n.Phone).IsRequired().HasMaxLength(12);
            });

            // Seed data (optional)
            modelBuilder.Entity<student>().HasData(
                new student { Id = 1, Name = "John Doe", Email = "john@gmail.com", Phone = "1234567890" },
                new student { Id = 2, Name = "Jane Smith", Email = "jane@gmail.com", Phone = "0987654321" },
                new student { Id = 3, Name = "Bobby", Email = "bobby@gmail.com", Phone = "1122334455" }
            );
        }
    }
}
