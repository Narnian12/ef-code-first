using System.Data.Entity;

namespace ef_code_first.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base() { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
