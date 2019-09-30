using BenchBnB.Models;
using System.Data.Entity;

namespace BenchBnB.Data
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            // Users
            var mo = new User()
            {
                FirstName = "Mo",
                LastName = "Salam",
                Email = "msalam@gmail.com",
                Password = "password"
            };
            context.Users.Add(mo);

            // Commit Data
            context.SaveChanges();
        }
    }
}