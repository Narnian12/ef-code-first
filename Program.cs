using ef_code_first.Data;
using System.Data.Entity.Migrations;

class Program
{
   static void Main(string[] args)
   {
      Console.Write("Welcome to the program. Please type 'c' if you want to create, 'r' if you want to read, 'u' if you want to update, 'd' if you want to delete, and 'end' if you want to finish the program: ");
      var command = Console.ReadLine();

      while (command != "end")
      {
         switch (command)
         {
            case "c":
               Console.Write("Please type the name of the person you want to create: ");
               var createdName = Console.ReadLine();
               Console.WriteLine("Creating " + createdName + "...");
               using ( var context = new SchoolContext() )
               {
                  var student = new Student()
                  {
                     StudentName = createdName ?? ""
                  };
                  context.Students.Add(student);
                  context.SaveChanges();
               }
               break;
            case "r":
               Console.WriteLine("Reading database...");
               using ( var context = new SchoolContext() )
               {
                  Console.WriteLine("Id, Name");
                  foreach (var student in context.Students)
                  {
                     Console.WriteLine(student.StudentID + ", " + student.StudentName);
                  }
               }
               break;
            case "u":
               Console.Write("Please type the name of the person you want to update: ");
               var updatedName = Console.ReadLine();
               using ( var context = new SchoolContext() )
               {
                  var student = context.Students.FirstOrDefault(c => c.StudentName == updatedName);
                  if (student != null)
                  {
                     Console.Write("Type the updated name you want the student to be called: ");
                     var newName = Console.ReadLine();
                     student.StudentName = newName ?? "";
                     context.Students.AddOrUpdate(student);
                     Console.WriteLine("Update complete");
                  }
                  else
                  {
                     Console.WriteLine("No student found with name " + updatedName);
                  }
               }
               break;
            case "d":
               Console.Write("Please type the name of the person you want to delete: ");
               var deletedName = Console.ReadLine();
               using ( var context = new SchoolContext() )
               {
                  var student = context.Students.FirstOrDefault(c => c.StudentName == deletedName);
                  if (student != null)
                  {
                     Console.WriteLine("Deleting " + deletedName + "...");
                     context.Students.Remove(student);
                     context.SaveChanges();
                  }
                  else
                  {
                     Console.WriteLine("Student " + deletedName + " not found, nothing was deleted.");
                  }
               }
               break;
            default:
               Console.Write("Invalid command. Please type 'c' if you want to create, 'r' if you want to read, 'u' if you want to update, 'd' if you want to delete, and 'end' if you want to finish the program: ");
               break;
         }
         Console.WriteLine();
         Console.Write("Please type 'c' if you want to create, 'r' if you want to read, 'u' if you want to update, 'd' if you want to delete, and 'end' if you want to finish the program: ");
         command = Console.ReadLine();
      }

      Console.WriteLine("Finished database manipulation");
   }
}
