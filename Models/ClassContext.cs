using Microsoft.EntityFrameworkCore;

namespace ClassRegistration.Models
{
    public class ClassContext : DbContext
    {
        public ClassContext(DbContextOptions<ClassContext> options)
            : base(options)
        { }

        public DbSet<GSUClass> GSUClasses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GSUClass>().HasData(
                new GSUClass
                {
                    CourseId = 1,
                    Name = "Advanced Operating System",
                    Number = "8735",
                    Department = "Computer Science",
                    Credit = 3,
                    Capacity = 20
                },
                new GSUClass
                {
                    CourseId = 2,
                    Name = "Project Management for Information Technology",
                    Number = "8820",
                    Department = "Computer Science",
                    Credit = 3,
                    Capacity = 20
                }
            );
        }
    }
}
