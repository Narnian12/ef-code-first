using System.Data.Entity;

namespace ef_code_first.Data
{
   public class SchoolContext : DbContext
   {
      // Add database name within base(...)
      public SchoolContext() : base() 
      {
         Database.SetInitializer( new CreateDatabaseIfNotExists<SchoolContext>());
      }

      public DbSet<Student> Students { get; set; }
      public DbSet<Grade> Grades { get; set; }
   }
}
