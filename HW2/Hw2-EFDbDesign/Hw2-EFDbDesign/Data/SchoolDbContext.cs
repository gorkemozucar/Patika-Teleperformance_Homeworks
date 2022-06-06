using Microsoft.EntityFrameworkCore;

namespace Hw2_EFDbDesign.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<School> Schools { get; set; }

    }
}
